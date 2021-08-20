using Microsoft.Graph;

using System;
using System.Collections.Generic;
using System.Linq;
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

      User result = new User();

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
        OpenTypeExtension resultExtension = new OpenTypeExtension() {
          Id = sourceExtension.Id,
          ExtensionName = sourceExtension.Id,
        };

        Dictionary<string, object> dict = new Dictionary<string, object>();

        foreach (var pair in sourceExtension.AdditionalData)
          dict.Add(pair.Key, pair.Value);

        resultExtension.AdditionalData = dict;

        result.Extensions.Add(resultExtension);
      }

      return result;
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
