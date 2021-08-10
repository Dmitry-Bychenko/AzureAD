using Microsoft.Graph;
using Microsoft.Identity.Client;

using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AzureAD {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Authentication
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public sealed class AzureADAuthentication : IAuthenticationProvider {
    #region Private Data

    private readonly string[] m_Scopes;

    private readonly Action<AzureADConnection> m_Action;

    private readonly AzureADConnection m_Connection;

    #endregion Private Data

    #region Algorithm

    private static (string code, string uri) ParseMessage(string message) {
      return (
        Regex.Match(message, @"code\s+(?<code>[A-Za-z0-9]+)").Groups["code"].Value,
        Regex.Match(message, @"https://[A-Za-z0-9/.:]+").Value
      );
    }

    #endregion Algorithm

    #region Create

    /// <summary>
    /// Standard constructor
    /// </summary>
    public AzureADAuthentication(AzureADConnection connection, Action<AzureADConnection> action) {
      m_Connection = connection ?? throw new ArgumentNullException(nameof(connection));
      m_Action = action; // ?? throw new ArgumentNullException(nameof(action));

      m_Scopes = connection.Permissions.ToArray();

      /*
      m_MsalClient = PublicClientApplicationBuilder
        .Create(m_Connection.ApplicationId)
        .WithAuthority(AadAuthorityAudience.AzureAdAndPersonalMicrosoftAccount, true)
        .Build();
      */

      Application = PublicClientApplicationBuilder
        .Create(m_Connection.ApplicationId)
        .WithAuthority(AzureCloudInstance.AzurePublic, connection.TenantId)
        //.WithRedirectUri("http://localhost")
        .WithDefaultRedirectUri()
        .Build();
    }

    /// <summary>
    /// Standard Constructor
    /// </summary>
    public AzureADAuthentication(AzureADConnection connection)
      : this(connection, null) { }

    #endregion Create

    #region Public

    /// <summary>
    /// Code
    /// </summary>
    public string Code { get; private set; }

    /// <summary>
    /// Url
    /// </summary>
    public string Url { get; private set; }

    /// <summary>
    /// Access Token
    /// </summary>
    public async Task<string> GetAccessToken() {
      AuthenticationResult result = null;

      if (UserAccount is not null) {
        result = await Application
          .AcquireTokenSilent(m_Scopes, UserAccount)
          .ExecuteAsync()
          .ConfigureAwait(false);

        return result.AccessToken;
      }
      if (!string.IsNullOrWhiteSpace(m_Connection.Login) &&
          !string.IsNullOrWhiteSpace(m_Connection.Password) &&
           Guid.TryParse(m_Connection.TenantId, out var _guid)) {
        try {
          System.Security.SecureString pwd = new();

          foreach (char c in m_Connection.Password)
            pwd.AppendChar(c);

          result = await Application
            .AcquireTokenByUsernamePassword(m_Scopes, m_Connection.Login, pwd)
            .ExecuteAsync()
            .ConfigureAwait(false);

          UserAccount = result.Account;

          return result.AccessToken;
        }
        catch (TaskCanceledException) {; }
        catch (TimeoutException) {; }
        catch (MsalClientException) {; }
        catch (MsalUiRequiredException) {; }
      }

      if (m_Action is not null) {
        try {
          result = await Application
            .AcquireTokenWithDeviceCode(
               m_Scopes,
               callback => {
                 var (code, uri) = ParseMessage(callback.Message);

                 Code = code;
                 Url = uri;

                 m_Action(m_Connection);

                 return Task.FromResult(0);
               })
            .ExecuteAsync()
            .ConfigureAwait(false);

          UserAccount = result.Account;

          return result.AccessToken;
        }
        catch (TaskCanceledException) {; }
        catch (TimeoutException) {; }
        catch (MsalClientException) {; }
        catch (MsalUiRequiredException) {; }
      }

      try {
        SystemWebViewOptions options = new () {
        };

        result = await Application
          .AcquireTokenInteractive(m_Scopes)
          .WithAccount(null)
          .WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
          .WithSystemWebViewOptions(options)
          .ExecuteAsync()
          .ConfigureAwait(false);

        UserAccount = result.Account;

        return result.AccessToken;
      }
      catch (TaskCanceledException) {; }
      catch (TimeoutException) {; }
      catch (MsalClientException) {; }
      catch (MsalUiRequiredException) {; }

      return null;
    }

    /// <summary>
    /// This is the required function to implement IAuthenticationProvider 
    /// The Graph SDK will call this function each time it makes a Graph Call
    /// </summary>
    public async Task AuthenticateRequestAsync(HttpRequestMessage requestMessage) {
      requestMessage.Headers.Authorization =
        new AuthenticationHeaderValue("bearer", await GetAccessToken().ConfigureAwait(false));
    }

    /// <summary>
    /// Application (MSA Client)
    /// </summary>
    public IPublicClientApplication Application { get; }

    /// <summary>
    /// User Account
    /// </summary>
    public IAccount UserAccount { get; private set; }

    #endregion Public
  }

}
