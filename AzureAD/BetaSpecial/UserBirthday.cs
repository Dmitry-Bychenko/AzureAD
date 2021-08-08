
using AzureAD.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureAD.BetaSpecial {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// 
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public static partial class AzureUserExtensions {
    #region Algorithm

    private static async Task DeleteBirthdays(AzureUser user) {
      if (user is null)
        return;

      using JsonDocument doc = await user.Connection.ReadJson($"beta/users/{user.User.Id}/profile/anniversaries");

      var array = doc
        .RootElement
        .GetProperty("value");

      List<string> ids = new ();

      for (int i = 0; i < array.GetArrayLength(); ++i) {
        var item = array[i];

        if (item.TryGetProperty("type", out var typeItem) && typeItem.GetString() == "birthday" &&
            item.TryGetProperty("id", out var idItem))
          ids.Add(idItem.GetString());
      }

      var tasks = ids
        .Where(id => !string.IsNullOrWhiteSpace(id))
        .Distinct()
        .Select(id => $"beta/users/{user.User.Id}/profile/anniversaries/{id}")
        .Select(address => user.Connection.Perform(address, "", HttpMethod.Delete))
        .ToArray();

      await Task.WhenAll(tasks);
    }

    #endregion Algorithm

    #region Public

    /// <summary>
    /// Get Birthday
    /// </summary>
    public static async Task<DateTime?> GetBirthday(this AzureUser user) {
      if (user is null)
        return null;

      using JsonDocument doc = await user.Connection.ReadJson($"beta/users/{user.User.Id}/profile/anniversaries");

      var array = doc
        .RootElement
        .GetProperty("value");

      for (int i = 0; i < array.GetArrayLength(); ++i) {
        var item = array[i];

        if (item.TryGetProperty("type", out var typeItem) && typeItem.GetString() == "birthday" &&
            item.TryGetProperty("date", out var dateItem))
          return dateItem.GetDateTime();
      }

      return null;
    }

    /// <summary>
    /// Set Birthday
    /// </summary>
    public static async Task SetBirthday(this AzureUser user, DateTime? value) {
      if (user is null)
        return;

      await DeleteBirthdays(user);

      if (!value.HasValue)
        return;

      string query = "{" + string.Join("," + Environment.NewLine,
        "\"type\": \"birthday\"",
       $"\"date\": \"{value.Value:yyyy-MM-dd}\"",
        "\"allowedAudiences\": \"everyone\"",
        "\"isSearchable\": true",
        "\"displayName\": \"Birthday\""
      ) + "}";

      var result = await user.Connection.Perform($"beta/users/{user.User.Id}/profile/anniversaries", query, HttpMethod.Post);

      if (!result.IsSuccessStatusCode)
        throw new InvalidOperationException($"{result.StatusCode} : {result.ReasonPhrase}");
    }

    #endregion Public
  }


}
