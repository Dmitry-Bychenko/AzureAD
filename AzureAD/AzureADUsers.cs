using Microsoft.Graph;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAD {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// 
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public static partial class AzureADConnectionExtensions {
    #region Private Data

    private static readonly IReadOnlyDictionary<string, bool> s_ExcludeProperties =
      new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase) {
        { "AboutMe", false },
        { "Birthday", false },
        { "DeviceEnrollmentLimit", false },
        { "HireDate", false },
        { "Interests", false },
        { "MailboxSettings", false },
        { "MySite", false },
        { "PastProjects", false },
        { "PreferredName", false },
        { "Responsibilities", false },
        { "Schools", false },
        { "Skills", false },
      };

    #endregion Private Data

    #region Algorithm

    private static string AllFields() {
      var fields = typeof(User)
        .GetProperties()
        .Where(p => p.DeclaringType == typeof(User))
        .Select(p => p.Name)
        .Where(name => !s_ExcludeProperties.ContainsKey(name))
        .OrderBy(name => name, StringComparer.OrdinalIgnoreCase);

      return "Id," + string.Join(",", fields);
    }

    #endregion Algorithm

    #region Public

    /// <summary>
    /// All users 
    /// </summary>
    /// <param name="connection">Connection to use</param>
    /// <param name="select">Fields to Select</param>
    /// <returns>All Users</returns>
    public static async Task<User[]> AllUsers(this AzureADConnection connection, string select) {
      if (connection is null)
        throw new ArgumentNullException(nameof(connection));

      if (!connection.IsConnected)
        return Array.Empty<User>();

      if (string.IsNullOrWhiteSpace(select))
        select = AllFields();
      else {
        select = string.Join(",", select
          .Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries)
          .Distinct(StringComparer.OrdinalIgnoreCase)
        );
      }

      var data = await connection
        .Connection
        .Users
        .Request()
        .Top(999)
        .Select(select)
        .GetAsync()
        .ConfigureAwait(false);

      List<User> result = new();

      PageIterator<User> pages = PageIterator<User>.CreatePageIterator(
        connection.Connection,
        data,
        item => {
          result.Add(item);

          return true;
        },
        pg => pg);

      await pages.IterateAsync().ConfigureAwait(false);

      return result.ToArray();
    }

    /// <summary>
    /// All users 
    /// </summary>
    /// <param name="connection">Connection to use</param>
    /// <returns>All Users</returns>
    public static async Task<User[]> AllUsers(this AzureADConnection connection) =>
      await AllUsers(connection, null);

    /// <summary>
    /// Enumerate users 
    /// </summary>
    /// <param name="connection">Connection to use</param>
    /// <param name="select">Fields to Select</param>
    /// <returns>Enumerate Users</returns>
    public static async IAsyncEnumerable<User> EnumerateUsers(this AzureADConnection connection, string select) {
      if (connection is null)
        throw new ArgumentNullException(nameof(connection));

      if (!connection.IsConnected)
        yield break;

      if (string.IsNullOrWhiteSpace(select))
        select = AllFields();
      else {
        select = string.Join(",", select
          .Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries)
          .Distinct(StringComparer.OrdinalIgnoreCase)
        );
      }

      int pageSize = 999;

      var data = await connection
          .Connection
          .Users
          .Request()
          .Top(pageSize)
          .Select(select)
          .GetAsync()
          .ConfigureAwait(false);

      while (true) {
        foreach (var user in data)
          yield return user;

        if (data.Count < pageSize)
          break;

        data = await data
          .NextPageRequest
          .GetAsync()
          .ConfigureAwait(false);
      }
    }

    /// <summary>
    /// Enumerate users 
    /// </summary>
    /// <param name="connection">Connection to use</param>
    /// <param name="select">Fields to Select</param>
    /// <returns>Enumerate Users</returns>
    public static async IAsyncEnumerable<User> EnumerateUsers(this AzureADConnection connection) {
      await foreach (var user in EnumerateUsers(connection, null))
        yield return user;
    }

    #endregion Public
  }

}
