
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureAD {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Http To Azure
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public static class AzureADHttp {
    #region Private Data

    private static CookieContainer s_CookieContainer;

    private static HttpClient s_HttpClient;

    #endregion Private Data

    #region Algorithm

    private static void CreateClient() {
      try {
        ServicePointManager.SecurityProtocol =
          SecurityProtocolType.Tls |
          SecurityProtocolType.Tls11 |
          SecurityProtocolType.Tls12;
      }
      catch (NotSupportedException) {
        ServicePointManager.SecurityProtocol =
          SecurityProtocolType.Tls |
          SecurityProtocolType.Tls11 |
          SecurityProtocolType.Tls12;
      }

      s_CookieContainer = new CookieContainer();

      var handler = new HttpClientHandler() {
        CookieContainer = s_CookieContainer
      };

      s_HttpClient = new HttpClient(handler);
    }

    private static string BuildAddress(string address) {
      // https://graph.microsoft.com/v1.0/

      if (string.IsNullOrWhiteSpace(address))
        return "";

      if (address.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        return address;

      if (address.StartsWith("v1.0/", StringComparison.OrdinalIgnoreCase))
        return $"https://graph.microsoft.com/{address}";

      if (address.StartsWith("/v1.0/", StringComparison.OrdinalIgnoreCase))
        return $"https://graph.microsoft.com{address}";

      if (address.StartsWith("beta/", StringComparison.OrdinalIgnoreCase))
        return $"https://graph.microsoft.com/{address}";

      if (address.StartsWith("/beta/", StringComparison.OrdinalIgnoreCase))
        return $"https://graph.microsoft.com{address}";

      if (address.StartsWith('/'))
        return $"https://graph.microsoft.com/v1.0{address}";

      return $"https://graph.microsoft.com/v1.0/{address}";
    }

    #endregion Algorithm

    #region Create

    static AzureADHttp() {
      CreateClient();
    }

    #endregion Create

    #region Public

    /// <summary>
    /// Client
    /// </summary>
    public static HttpClient Client => s_HttpClient;

    /// <summary>
    /// Image 
    /// </summary>
    public static async Task<HttpResponseMessage> Image(this AzureADConnection connection, string address) {
      if (connection is null)
        throw new ArgumentNullException(nameof(connection));

      if (address is null)
        throw new ArgumentNullException(nameof(address));

      address = BuildAddress(address);

      string bearer = await connection.FreshBearer().ConfigureAwait(false);

      using var req = new HttpRequestMessage {
        Method = HttpMethod.Get,
        RequestUri = new Uri(address),
        Headers = {
          { HttpRequestHeader.Authorization.ToString(), $"Bearer {bearer}" },
          { HttpRequestHeader.Accept.ToString(), "image/jpg" },
        },
        Content = new StringContent("", Encoding.UTF8, "application/json")
      };

      return await s_HttpClient.SendAsync(req).ConfigureAwait(false);
    }

    /// <summary>
    /// Perform 
    /// </summary>
    public static async Task<HttpResponseMessage> Perform(this AzureADConnection connection,
                                                               string address,
                                                               string query,
                                                               HttpMethod method) {
      if (connection is null)
        throw new ArgumentNullException(nameof(connection));
      if (address is null)
        throw new ArgumentNullException(nameof(address));

      address = BuildAddress(address);

      query = string.IsNullOrWhiteSpace(query) ? "{}" : query;

      string bearer = await connection.FreshBearer().ConfigureAwait(false);

      using var req = new HttpRequestMessage {
        Method = method,
        RequestUri = new Uri(address),
        Headers = {
          { HttpRequestHeader.Authorization.ToString(), $"Bearer {bearer}" },
          { HttpRequestHeader.Accept.ToString(), "application/json" },
        },
        Content = new StringContent(query, Encoding.UTF8, "application/json")
      };

      return await s_HttpClient.SendAsync(req).ConfigureAwait(false);
    }
    /// <summary>
    /// Read JSON
    /// </summary>
    public static async Task<JsonDocument> ReadJson(this AzureADConnection connection,
                                                         string address) {
      if (connection is null)
        throw new ArgumentNullException(nameof(connection));
      if (address is null)
        throw new ArgumentNullException(nameof(address));

      var response = await Perform(connection, address, "", HttpMethod.Get);

      if (!response.IsSuccessStatusCode)
        throw new InvalidOperationException($"{response.StatusCode} : {response.ReasonPhrase}");

      string text = await response.Content.ReadAsStringAsync();

      return JsonDocument.Parse(text);
    }

    /// <summary>
    /// Read JSON
    /// </summary>
    public static async Task<JsonDocument> ReadJson(this AzureADConnection connection,
                                                         string address,
                                                         string query) {
      if (connection is null)
        throw new ArgumentNullException(nameof(connection));
      if (address is null)
        throw new ArgumentNullException(nameof(address));

      var response = await Perform(connection, address, query, HttpMethod.Put);

      if (!response.IsSuccessStatusCode)
        throw new InvalidOperationException($"{response.StatusCode} : {response.ReasonPhrase}");

      string text = await response.Content.ReadAsStringAsync();

      return JsonDocument.Parse(text);
    }

    #endregion Public
  }

}
