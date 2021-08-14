using Microsoft.Graph;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureAD.Structure {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Azure User
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public sealed class AzureUser : IEquatable<AzureUser> {
    #region Private Data

    private static readonly ConcurrentDictionary<User, AzureUser> s_UserDict = new();

    private List<AzureUser> m_Subordinates;

    private byte[] m_Image;

    #endregion Private Data

    #region Algorithm

    private async Task<byte[]> CoreLoadImage() {
      using Stream stream = await GraphClient
        .Users[User.UserPrincipalName]
        .Photo
        .Content
        .Request()
        .GetAsync()
        .ConfigureAwait(false);

      if (stream is null)
        return Array.Empty<byte>();

      byte[] result = new byte[(int)(stream.Length)];

      stream.Read(result, 0, result.Length);

      return result;
    }

    private async Task CoreSaveImage(byte[] data) {
      if (data is null || data.Length <= 0)
        return;

      using var stream = new System.IO.MemoryStream(data);

      await GraphClient
        .Users[User.UserPrincipalName]
        .Photo
        .Content
        .Request()
        .PutAsync(stream)
        .ConfigureAwait(false);

      m_Image = data.ToArray();
    }

    #endregion Algorithm

    #region Create

    internal AzureUser(AzureEnterprise enterprise, User user) {
      Enterprise = enterprise;
      User = user;

      s_UserDict.TryAdd(user, this);
    }

    #endregion Create

    #region Public

    /// <summary>
    /// Enterprise
    /// </summary>
    public AzureEnterprise Enterprise { get; }

    /// <summary>
    /// Connection
    /// </summary>
    public AzureADConnection Connection => Enterprise.Connection;

    /// <summary>
    /// Graph Client
    /// </summary>
    public GraphServiceClient GraphClient => Enterprise.Connection.Connection;

    /// <summary>
    /// User
    /// </summary>
    public User User { get; }

    /// <summary>
    /// Is Modified
    /// </summary>
    public bool IsModified { get; set; }

    /// <summary>
    /// Manager
    /// </summary>
    public AzureUser Manager => Enterprise.FindUser(User.Manager?.Id);

    /// <summary>
    /// Root Manager
    /// </summary>
    public AzureUser RootManager {
      get {
        AzureUser result = this;

        while (true) {
          AzureUser manager = result.Manager;

          if (manager is null)
            return result;

          result = manager;
        }
      }
    }

    /// <summary>
    /// Subordinates
    /// </summary>
    public IReadOnlyList<AzureUser> Subordinates {
      get {
        if (m_Subordinates is not null)
          return m_Subordinates;

        m_Subordinates = Enterprise
          .Users
          .Where(user => ReferenceEquals(user.Manager, this))
          .ToList();

        return m_Subordinates;
      }
    }

    /// <summary>
    /// Get Image Data
    /// </summary>
    public async Task<byte[]> GetImageData(bool force = false) {
      if (m_Image is not null && !force)
        return m_Image;

      try {
        m_Image = await CoreLoadImage().ConfigureAwait(false);
      }
      catch (ServiceException) {
        m_Image = Array.Empty<byte>();
      }

      return m_Image;
    }

    /// <summary>
    /// Set Image Data
    /// </summary>
    public async Task<bool> SetImageData(byte[] data, bool force = false) {
      if (data is null)
        data = Array.Empty<byte>();

      if (data.SequenceEqual(m_Image) && !force)
        return true;

      try {
        await CoreSaveImage(data).ConfigureAwait(false);

        return true;
      }
      catch (ServiceException) {
        return false;
      }
    }

    /// <summary>
    /// Create Directory (in One Note)
    /// </summary>
    public async Task<bool> CreateDirectory(string directoryName) {
      if (string.IsNullOrWhiteSpace(directoryName))
        return false;

      var driveItem = new DriveItem {
        Name = directoryName,
        Folder = new Folder { },
        AdditionalData = new Dictionary<string, object>()  {
          {"@microsoft.graph.conflictBehavior", "replace"}
        }
      };

      try {
        await GraphClient
          .Users[User.Id]
          .Drive
          .Root
          .Children
          .Request()
          .AddAsync(driveItem)
          .ConfigureAwait(false);

        return true;
      }
      catch (ServiceException) {
        return false;
      }
    }

    /// <summary>
    /// Delete File or Directory
    /// </summary>
    public async Task<bool> DeleteFileOrDirectory(string fileName) {
      if (string.IsNullOrWhiteSpace(fileName))
        return false;

      try {
        await GraphClient
          .Users[User.Id]
          .Drive
          .Root
          .ItemWithPath(fileName)
          .Request()
          .DeleteAsync()
          .ConfigureAwait(false);

        return true;
      }
      catch (ServiceException) {
        return false;
      }
    }

    /// <summary>
    /// Read File
    /// </summary>
    public async Task<byte[]> ReadFile(string fileName) {
      if (string.IsNullOrWhiteSpace(fileName))
        return Array.Empty<byte>();

      try {
        var path = GraphClient
          .Users[User.Id]
          .Drive
          .Root;

        if (!string.IsNullOrEmpty(fileName))
          path = path.ItemWithPath(fileName);

        var stream = await path
          .Content
          .Request()
          .GetAsync()
          .ConfigureAwait(false);

        byte[] data = new byte[stream.Length];

        for (int i = 0; i < data.Length; ++i)
          data[i] = (byte)(stream.ReadByte());

        return data;
      }
      catch (ServiceException) {
        return Array.Empty<byte>();
      }
    }

    /// <summary>
    /// Write file
    /// </summary>
    public async Task<bool> WriteFile(string fileName, IEnumerable<byte> data) {
      if (string.IsNullOrWhiteSpace(fileName))
        return false;

      if (data is null)
        return false;

      try {
        using var stream = new MemoryStream(data.ToArray());

        var path = GraphClient
          .Users[User.Id]
          .Drive
          .Root;

        if (!string.IsNullOrEmpty(fileName))
          path = path.ItemWithPath(fileName);

        var result = await path
          .Content
          .Request()
          .PutAsync<DriveItem>(stream)
          .ConfigureAwait(false);

        return true;
      }
      catch (ServiceException) {
        return false;
      }
    }

    /// <summary>
    /// Enumerate Files
    /// </summary>
    public async IAsyncEnumerable<string> EnumerateFiles(string directory) {
      var path = GraphClient
          .Users[User.Id]
          .Drive
          .Root;

      if (!string.IsNullOrEmpty(directory))
        path = path.ItemWithPath(directory);

      IDriveItemChildrenCollectionPage data = null;

      try {
        data = await path
          .Children
          .Request()
          .GetAsync()
          .ConfigureAwait(false);
      }
      catch (ServiceException) {
        yield break;
      }

      var items = data
        .Where(item => item.Folder == null)
        .Select(item => item.Name);

      foreach (var item in items)
        yield return item;
    }

    /// <summary>
    /// Enumerate Directories
    /// </summary>
    public async IAsyncEnumerable<string> EnumerateDirectories(string directory) {
      var path = GraphClient
          .Users[User.Id]
          .Drive
          .Root;

      if (!string.IsNullOrEmpty(directory))
        path = path.ItemWithPath(directory);

      var data = await path
        .Children
        .Request()
        .GetAsync()
        .ConfigureAwait(false);

      var items = data
        .Where(item => item.Folder != null)
        .Select(item => item.Name);

      foreach (var item in items)
        yield return item;
    }

    /// <summary>
    /// File Objects
    /// </summary>
    public async Task<IDriveItemChildrenCollectionPage> FileObjects(string directory) {
      var path = GraphClient
          .Users[User.Id]
          .Drive
          .Root;

      if (!string.IsNullOrEmpty(directory))
        path = path.ItemWithPath(directory);

      return await path
        .Children
        .Request()
        .GetAsync()
        .ConfigureAwait(false);
    }

    /// <summary>
    /// Send Chat Message 
    /// </summary>
    public async Task<bool> SendChatMessage(string teamId, string message, BodyType bodyType) {
      if (string.IsNullOrWhiteSpace(message))
        return false;

      var chatMessage = new ChatMessage {
        CreatedDateTime = DateTime.Now,
        From = new ChatMessageFromIdentitySet {
          User = new Identity {
            //Id = "id-value",
            DisplayName = User.DisplayName,
          }
        },
        Body = new ItemBody {
          ContentType = bodyType,
          Content = message
        }
      };

      if (string.IsNullOrWhiteSpace(teamId))
        return false;

      var team = GraphClient
        .Teams[teamId];

      if (team is null)
        return false;

      var channel = await team
        .PrimaryChannel
        .Request()
        .GetAsync();

      if (channel is null)
        return false;

      await GraphClient
        .Teams[teamId]
        .Channels[channel.Id]
        .Messages
        .Request()
        .AddAsync(chatMessage);

      return true;
    }

    /// <summary>
    /// Send Chat Message 
    /// </summary>
    public async Task<bool> SendChatMessage(string teamId, string message) =>
      await SendChatMessage(teamId, message, BodyType.Html);

    /// <summary>
    /// Extension By Name (null when not found)
    /// </summary>
    public Extension ExtensionByName(string name) {
      if (string.IsNullOrEmpty(name))
        return null;

      if (User.Extensions is null)
        return null;

      foreach (var ext in User.Extensions)
        if (string.Equals(ext.Id, name, StringComparison.OrdinalIgnoreCase))
          return ext;  
    
      return null;
    }

    /// <summary>
    /// Extension Value (ValueKind == JsonValueKind.Undefined when not found)
    /// </summary>
    public JsonElement ExtensionValue(string extensionName, string valueName) {
      if (valueName is null)
        return new JsonElement();

      var ext = ExtensionByName(extensionName);

      if (ext is null)
        return new JsonElement();

      if (ext.AdditionalData.TryGetValue(valueName, out var value) && value is JsonElement result)
        return result;

      return new JsonElement();
    }

    /// <summary>
    /// To String (Display Name)
    /// </summary>
    public override string ToString() => User?.DisplayName ?? "?";

    #endregion Public

    #region Operators

    #region Cast

    /// <summary>
    /// To MS Graph User
    /// </summary>
    public static implicit operator User(AzureUser value) => value?.User;

    /// <summary>
    /// From MS Graph User 
    /// </summary>
    public static implicit operator AzureUser(User value) =>
      s_UserDict.TryGetValue(value, out var result) ? result : default;

    #endregion Cast

    #region Compare

    /// <summary>
    /// Equals 
    /// </summary>
    public static bool operator ==(AzureUser left, AzureUser right) {
      if (ReferenceEquals(left, right))
        return true;
      if (left is null || right is null)
        return false;

      return left.Equals(right);
    }

    /// <summary>
    /// Not Equals 
    /// </summary>
    public static bool operator !=(AzureUser left, AzureUser right) {
      if (ReferenceEquals(left, right))
        return false;
      if (left is null || right is null)
        return true;

      return !left.Equals(right);
    }

    #endregion Compare

    #endregion Operators

    #region IEquatable<AzureUser>

    /// <summary>
    /// Equals 
    /// </summary>
    public bool Equals(AzureUser other) {
      if (ReferenceEquals(this, other))
        return true;
      if (other is null)
        return false;

      return string.Equals(User?.Id, other.User?.Id);
    }

    /// <summary>
    /// Equals
    /// </summary>
    public override bool Equals(object obj) => obj is AzureUser other && Equals(other);

    /// <summary>
    /// Hash Code
    /// </summary>
    public override int GetHashCode() {
      if (User is null)
        return -1;
      if (User.Id is null)
        return -2;

      return User.Id.GetHashCode();
    }


    #endregion IEquatable<AzureUser>
  }

}
