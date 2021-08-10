using Microsoft.Graph;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAD.Structure {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// 
  /// </summary>
  //
  // https://docs.microsoft.com/en-us/graph/api/resources/user?view=graph-rest-1.0
  //
  //-------------------------------------------------------------------------------------------------------------------
   
  public sealed class AzureEnterprise {
    #region Private Data

    private readonly List<AzureUser> m_Users = new ();

    private readonly Dictionary<string, AzureUser> m_UserDict = new (StringComparer.OrdinalIgnoreCase);

    private readonly string m_Selection;

    private IProgress<AzureUser> m_Progress;

    #endregion Private Data

    #region Algorithm

    private async Task CoreLoadUsers() {
      await foreach (var user in Connection.EnumerateUsers(m_Selection).ConfigureAwait(false)) {
        var azureUser = new AzureUser(this, user);

        m_Users.Add(azureUser);

        m_UserDict.TryAdd(user.Id, azureUser);
        m_UserDict.TryAdd(user.UserPrincipalName, azureUser);

        //if (m_Progress is not null)
        //  m_Progress.Report(azureUser);
      }

      m_Users.Sort((left, right) => string.Compare(left.User.DisplayName, right.User.DisplayName, StringComparison.OrdinalIgnoreCase));

      // Master Domain Computation
      foreach (var user in m_Users) {
        string name = user.User.UserPrincipalName;

        if (!string.IsNullOrEmpty(name)) {
          int p = name.IndexOf('@');

          if (p >= 0) {
            MasterDomain = name[(p + 1)..];

            break;
          }
        }
      }

      var me = await Connection
        .Connection
        .Me
        .Request()
        .GetAsync()
        .ConfigureAwait(false);

      Me = m_UserDict[me.Id];
    }

    private async Task CoreLoad() {
      if (m_Progress is not null)
        m_Progress.Report(null);

      await CoreLoadUsers().ConfigureAwait(false);
       
      m_Progress = null;
    }

    #endregion Algorithm

    #region Create

    // Standard Constructor
    private AzureEnterprise(AzureADConnection connection, 
                            string selection,
                            IProgress<AzureUser> progress) {
      Connection = connection ?? throw new ArgumentNullException(nameof(connection));
      m_Progress = progress;
       
      m_Selection = string.IsNullOrWhiteSpace(selection)
        ? ""
        : "Id,UserPrincipleName,DisplayName,Mail," + selection;
    }

    /// <summary>
    /// Create Instance
    /// </summary>
    /// <param name="connection">Connection to use</param>
    public static async Task<AzureEnterprise> Create(AzureADConnection connection, 
                                                     string selection,
                                                     IProgress<AzureUser> progress) {
      AzureEnterprise result = new (connection, selection, progress);

      await result.CoreLoad().ConfigureAwait(false);

      return result;
    }

    /// <summary>
    /// Create Instance
    /// </summary>
    /// <param name="connection">Connection to use</param>
    public static async Task<AzureEnterprise> Create(AzureADConnection connection, string selection) =>
      await Create(connection, selection, null).ConfigureAwait(false);

    /// <summary>
    /// Create Instance
    /// </summary>
    /// <param name="connection">Connection to use</param>
    public static async Task<AzureEnterprise> Create(AzureADConnection connection, IProgress<AzureUser> progress) =>
      await Create(connection, null, progress).ConfigureAwait(false);

    /// <summary>
    /// Create Instance
    /// </summary>
    /// <param name="connection">Connection to use</param>
    public static async Task<AzureEnterprise> Create(AzureADConnection connection) =>
      await Create(connection, null, null).ConfigureAwait(false);

    #endregion Create

    #region Public

    /// <summary>
    /// Connection
    /// </summary>
    public AzureADConnection Connection { get; }

    /// <summary>
    /// Graph Client
    /// </summary>
    public GraphServiceClient GraphClient => Connection.Connection;

    /// <summary>
    /// Master Domain
    /// </summary>
    public string MasterDomain { get; private set; }

    /// <summary>
    /// Me
    /// </summary>
    public AzureUser Me { get; private set; }

    /// <summary>
    /// Users
    /// </summary>
    public IReadOnlyList<AzureUser> Users => m_Users;

    /// <summary>
    /// Find User
    /// </summary>
    public AzureUser FindUser(string nameOrKey) =>
      !string.IsNullOrWhiteSpace(nameOrKey) && m_UserDict.TryGetValue(nameOrKey, out var result)
         ? result
         : default;

    #endregion Public
  }

}
