using Microsoft.Graph;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace AzureAD.Structure {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// 
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public sealed class AzureImportUser {
    #region Private Data
    #endregion Private Data

    #region Algorithm

    private static User CloneUser(User source) {
      if (source is null)
        return null;

      User result = new ();

      result.Id = source.Id;
      result.UserPrincipalName = source.UserPrincipalName;

      var properties = typeof(User)
        .GetProperties()
        .Where(p => p.DeclaringType == typeof(User))
        .Where(p => p.CanWrite && p.CanRead)
        .Where(p => !p.GetGetMethod().IsStatic)
        .Where(p => p.GetGetMethod().IsPublic);

      foreach (PropertyInfo prop in properties) {
        object value = prop.GetValue(source);

        // if (value is IEnumerable<string> array)
        //   value = array.ToArray();

        prop.SetValue(result, value);
      }

      foreach (Extension sourceExtension in source.Extensions) {
        OpenTypeExtension resultExtension = new () {
          Id = sourceExtension.Id,
          ExtensionName = sourceExtension.Id,
        };

        Dictionary<string, object> dict = new ();

        foreach (var pair in sourceExtension.AdditionalData)
          dict.Add(pair.Key, pair.Value);

        resultExtension.AdditionalData = dict;

        result.Extensions.Add(resultExtension);
      }

      return result;
    }

    private static Dictionary<string, object> UserInsertData(User source) {
      Dictionary<string, object> result = new ();

      if (source is null)
        return result;

      var properties = typeof(User)
        .GetProperties()
        .Where(p => p.DeclaringType == typeof(User))
        .Where(p => p.CanWrite && p.CanRead)
        .Where(p => !p.GetGetMethod().IsStatic)
        .Where(p => p.GetGetMethod().IsPublic)
        .Select(p => (key : p.Name, value : p.GetValue(source)));

      foreach (var pair in properties)
        if (pair.value is not null)
          result.Add(pair.key, pair.value);

      return result;
    }

    private static Dictionary<string, object> UserUpdateData(User source, User previous) {
      Dictionary<string, object> result = new();

      if (source is null)
        return result;

      var properties = typeof(User)
        .GetProperties()
        .Where(p => p.DeclaringType == typeof(User))
        .Where(p => p.CanWrite && p.CanRead)
        .Where(p => !p.GetGetMethod().IsStatic)
        .Where(p => p.GetGetMethod().IsPublic);

      foreach (var prop in properties) {
        object v1 = prop.GetValue(source);
        object v2 = prop.GetValue(previous);

        if (object.Equals(v1, v2))
          continue;

        result.Add(prop.Name, v1);
      }

      return result;
    }

    internal async Task<string> CoreManagerUpdate() {
      if (ImportKind == AzureImportKind.None)
        return "";
      if (!Checked)
        return "";

      string managerId = User?.Manager?.Id;

      if (managerId == SourceUser?.Manager?.Id)
        return "";

      string address =
        $"https://graph.microsoft.com/v1.0/users/{User.Id}/manager/$ref";

      string query = string.IsNullOrWhiteSpace(managerId)
        ? ""
        : $"{{ \"@odata.id\": \"https://graph.microsoft.com/v1.0/users/{managerId}\" }}";

      using HttpResponseMessage response = await Enterprise.Connection.Perform(
        address, query, string.IsNullOrWhiteSpace(managerId) ? HttpMethod.Delete : HttpMethod.Put);

      if (response.IsSuccessStatusCode)
        return "";

      return response.ReasonPhrase;
    }

    private async Task CorePerformExtensions() {
      // Remove
      if (SourceUser is not null)
        foreach (var sourceExtension in SourceUser.Extensions) {
          if (!User.Extensions.Any(item => item.Id == sourceExtension.Id)) {
            await GraphClient
              .Users[SourceUser.Id]
              .Extensions[sourceExtension.Id]
              .Request()
              .DeleteAsync();
          }
        }

      // Add or Update
      foreach (var sourceExtension in User.Extensions) {
        OpenTypeExtension extension = new () {
          Id = sourceExtension.Id,
          ExtensionName = sourceExtension.Id,
        };

        extension.AdditionalData = sourceExtension.AdditionalData;

        var srcExtension = SourceUser?.Extensions?.FirstOrDefault(item => item.Id == sourceExtension.Id);

        if (srcExtension is not null && srcExtension.AdditionalData.Count == extension.AdditionalData.Count) {
          bool allEqual = true;

          foreach (var pair in srcExtension.AdditionalData)
            if (!extension.AdditionalData.TryGetValue(pair.Key, out var value) || !object.Equals(pair.Value, value)) {
              allEqual = false;

              break;
            }

          if (allEqual)
            continue;
        }

        if (SourceUser?.Extensions?.Any(item => item.Id == sourceExtension.Id) ?? false)
          await GraphClient
            .Users[User.Id]
            .Extensions[extension.Id]
            .Request()
            .UpdateAsync(extension);
        else  
          await GraphClient
            .Users[User.Id]
            .Extensions[extension.Id]
            .Request()
            .PutAsync(extension);
      }
    }

    private async Task CorePerformInsert() {
      var user = new User() {
        Id = User.Id,
        AccountEnabled = true,
        PasswordProfile = new PasswordProfile {
          Password = $"Temporal: {Guid.NewGuid()}",
          ForceChangePasswordNextSignIn = true
        },
      };

      user.Id = User.Id;

      user.AdditionalData = UserInsertData(User);

      if (string.IsNullOrWhiteSpace(User.UserPrincipalName)) {
        string mail = string.IsNullOrWhiteSpace(user.Mail)
          ? $"{user.Id}@{Enterprise.MasterDomain}"
          : $"{user.Mail}@{Enterprise.MasterDomain}";

        if (Enterprise.FindUser(mail) is null && Import.Find(mail) is null)
          user.UserPrincipalName = mail;
        else
          user.UserPrincipalName = $"{user.Id}@{Enterprise.MasterDomain}";
      }

      await GraphClient
        .Users
        .Request()
        .AddAsync(user);
    }

    private async Task CorePerformUpdate() {
      var user = new User() {
        Id = SourceUser.Id,
        UserPrincipalName = SourceUser.UserPrincipalName,
      };

      user.AdditionalData = UserUpdateData(User, SourceUser);

      if (user.AdditionalData.Count > 0)
        await GraphClient
          .Users[user.Id]
          .Request()
          .UpdateAsync(user); 
    }

    private async Task CorePerformDelete() {
      await GraphClient
        .Users[User.Id]
        .Request()
        .DeleteAsync();
    }

    internal async Task CorePerformAction() {
      if (ImportKind == AzureImportKind.None)
        return;
      if (!Checked)
        return;

      if (ImportKind == AzureImportKind.Delete || ImportKind == AzureImportKind.Garbage)
        await CorePerformDelete();
      else if (ImportKind == AzureImportKind.Insert) {
        await CorePerformInsert();

        await CorePerformExtensions();
      }
      else if (ImportKind == AzureImportKind.Update) {
        await CorePerformUpdate();

        await CorePerformExtensions();
      }
    }

    #endregion Algorithm

    #region Create

    internal AzureImportUser(AzureImport import, User user) {
      Import = import ?? throw new ArgumentNullException(nameof(import));

      User = CloneUser(user);
    }

    #endregion Create

    #region Public

    /// <summary>
    /// Checked
    /// </summary>
    public bool Checked { get; set; } = true;

    /// <summary>
    /// Import Kind
    /// </summary>
    public AzureImportKind ImportKind { get; set; } = AzureImportKind.Garbage;

    /// <summary>
    /// Import
    /// </summary>
    public AzureImport Import { get; }

    /// <summary>
    /// Enterprise
    /// </summary>
    public AzureEnterprise Enterprise => Import.Enterprise;

    /// <summary>
    /// Graph Client
    /// </summary>
    public GraphServiceClient GraphClient => Import.Enterprise.GraphClient;

    /// <summary>
    /// User
    /// </summary>
    public User User { get; }

    /// <summary>
    /// Source User
    /// </summary>
    public User SourceUser => User is null
      ? null
      : Enterprise.FindUser(User.Id)?.User;

    #endregion Public
  }

}
