using Microsoft.Graph;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAD {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Azure AD Connection
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public sealed class AzureADConnection {
    #region Private Data

    private readonly Action<AzureADConnection> m_CallBack;

    #endregion Private Data

    #region Algorithm
    #endregion Algorithm

    #region Create

    /// <summary>
    /// Standard Constructor
    /// </summary>
    /// <param name="applicationId">Application</param>
    /// <param name="permissions">Permissions</param>
    /// <param name="callBack">CallBack</param>
    public AzureADConnection(string applicationId,
                             IEnumerable<string> permissions,
                             Action<AzureADConnection> callBack,
                             string tenantId) {
      ApplicationId = applicationId?.Trim() ?? throw new ArgumentNullException(nameof(applicationId));

      TenantId = string.IsNullOrWhiteSpace(tenantId) ? "common" : tenantId.Trim();

      if (permissions is null)
        throw new ArgumentNullException(nameof(permissions));

      Permissions = permissions
        .Where(item => !string.IsNullOrWhiteSpace(item))
        .Select(item => item.Trim())
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .OrderBy(item => item, StringComparer.OrdinalIgnoreCase)
        .ToList();

      m_CallBack = callBack; // ?? throw new ArgumentNullException(nameof(callBack));

      Authentication = new AzureADAuthentication(this, m_CallBack);
    }

    /// <summary>
    /// Standard Constructor
    /// </summary>
    /// <param name="applicationId">Application</param>
    /// <param name="permissions">Permissions</param>
    /// <param name="callBack">CallBack</param>
    public AzureADConnection(string applicationId,
                             IEnumerable<string> permissions,
                             Action<AzureADConnection> callBack)
      : this(applicationId, permissions, callBack, "common") { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="permissions"></param>
    /// <param name="tenantId"></param>
    /// <param name="login"></param>
    /// <param name="password"></param>
    public AzureADConnection(string applicationId,
                             IEnumerable<string> permissions,
                             string tenantId,
                             string login,
                             string password) {
      ApplicationId = applicationId?.Trim() ?? throw new ArgumentNullException(nameof(applicationId));

      TenantId = string.IsNullOrWhiteSpace(tenantId) ? "common" : tenantId.Trim();

      Login = login is null ? "" : login.Trim();
      Password = password is null ? "" : password.Trim();

      if (permissions is null)
        throw new ArgumentNullException(nameof(permissions));

      Permissions = permissions
        .Where(item => !string.IsNullOrWhiteSpace(item))
        .Select(item => item.Trim())
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .OrderBy(item => item, StringComparer.OrdinalIgnoreCase)
        .ToList();

      Authentication = new AzureADAuthentication(this, m_CallBack);
    }

    /// <summary>
    /// Standard Constructor
    /// </summary>
    /// <param name="connectionString">Connection String</param>
    public AzureADConnection(string connectionString) {
      if (connectionString is null)
        throw new ArgumentNullException(nameof(connectionString));

      DbConnectionStringBuilder builder = new() {
        ConnectionString = connectionString
      };

      ApplicationId = builder.TryGetValue("Application", out var applicationId)
        ? applicationId?.ToString()
        : throw new ArgumentException("Application must be set", nameof(connectionString));

      TenantId = builder.TryGetValue("Tenant", out var tenantId)
        ? tenantId?.ToString() ?? "common"
        : "common";

      Login = builder.TryGetValue("Logon", out var login)
        ? login?.ToString() ?? Environment.UserName
        : Environment.UserName;

      Password = builder.TryGetValue("Password", out var password)
        ? password?.ToString() ?? ""
        : "";

      string perms = builder.TryGetValue("Permissions", out var perm)
        ? perm?.ToString() ?? "User.ReadBasic.All"
        : "User.ReadBasic.All";

      Permissions = perms
        .Split(new char[] { ',', ';', ' ', '\t'}, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .Where(item => !string.IsNullOrWhiteSpace(item))
        .Select(item => item.Trim())
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .OrderBy(item => item, StringComparer.OrdinalIgnoreCase)
        .ToList();

      Authentication = new AzureADAuthentication(this, m_CallBack);
    }

    /// <summary>
    /// 
    /// </summary>
    public AzureADConnection(string applicationId,
                             IEnumerable<string> permissions)
      : this(applicationId, permissions, null) { }

    #endregion Create

    #region Public

    /// <summary>
    /// Application ID
    /// </summary>
    public string ApplicationId { get; }

    /// <summary>
    /// Tenant ID
    /// </summary>
    public string TenantId { get; }

    /// <summary>
    /// Login
    /// </summary>
    public string Login { get; } = "";

    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; } = "";

    /// <summary>
    /// Permissions
    /// </summary>
    public IReadOnlyList<string> Permissions { get; }

    /// <summary>
    /// Connection
    /// </summary>
    public GraphServiceClient Connection { get; private set; }

    /// <summary>
    /// Authentication
    /// </summary>
    public AzureADAuthentication Authentication { get; private set; }

    /// <summary>
    /// Is Connected
    /// </summary>
    public bool IsConnected => Connection is not null;

    /// <summary>
    /// Bearer
    /// </summary>
    public string Bearer { get; private set; }

    /// <summary>
    /// Bearer
    /// </summary>
    public async Task<string> FreshBearer() {
      string token = await Authentication.GetAccessToken().ConfigureAwait(false);

      if (Connection is null) {
        Connection = new GraphServiceClient(Authentication);

        Bearer = token;

        var evt = Connected;

        if (evt is not null)
          evt.Invoke(this, EventArgs.Empty);
      }

      Bearer = token;

      return token;
    }

    /// <summary>
    /// Connect
    /// </summary>
    public async Task<bool> Connect() {
      if (Connection is not null)
        return true;

      string token = await Authentication.GetAccessToken().ConfigureAwait(false);

      if (string.IsNullOrWhiteSpace(token))
        return false;

      Connection = new GraphServiceClient(Authentication);

      Bearer = token;

      var evt = Connected;

      if (evt is not null)
        evt.Invoke(this, EventArgs.Empty);

      return true;
    }

    /// <summary>
    /// Show Authentication
    /// </summary>
    public bool ShowAuthentication() {
      if (Connection is not null)
        return false;

      if (string.IsNullOrWhiteSpace(Authentication.Url))
        return false;

      using (System.Diagnostics.Process.Start(new ProcessStartInfo {
        FileName = Authentication.Url,
        UseShellExecute = true
      })) { }

      return true;
    }

    /// <summary>
    /// Show Explorer
    /// </summary>
    public static bool ShowExplorer() {
      using (System.Diagnostics.Process.Start(new ProcessStartInfo {
        FileName = @"https://developer.microsoft.com/en-us/graph/graph-explorer",
        UseShellExecute = true
      })) { }

      return true;
    }

    /// <summary>
    /// Show Portal
    /// </summary>
    public static bool ShowAzurePortal() {
      // https://azure.microsoft.com/en-us/features/azure-portal/
      using (System.Diagnostics.Process.Start(new ProcessStartInfo {
        FileName = @"https://azure.microsoft.com/en-us/features/azure-portal",
        UseShellExecute = true
      })) { }

      return true;
    }

    /// <summary>
    /// To String
    /// </summary>
    public override string ToString() =>
      $"{(IsConnected ? "Connected to" : "Not Connected to ")} : {ApplicationId} ({string.Join(", ", Permissions)})";

    /// <summary>
    /// On Connected
    /// </summary>
    public event EventHandler Connected;

    #endregion Public

    #region Operators

    /// <summary>
    /// To Standard Graph Service Client
    /// </summary>
    public static implicit operator GraphServiceClient(AzureADConnection value) =>
      value?.Connection;

    #endregion Operators
  }

}
