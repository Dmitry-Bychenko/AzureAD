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
  //-------------------------------------------------------------------------------------------------------------------

  public enum AzureImportKind {
    None = 0,
    Insert = 1,
    Delete = 2,
    Update = 3,
    Garbage = 4,
  }

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// 
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public sealed class AzureImport {
    #region Private Data

    private readonly List<AzureImportUser> m_Items = new ();

    private readonly Dictionary<string, AzureImportUser> m_Dictionary = new(StringComparer.OrdinalIgnoreCase);

    #endregion Private Data

    #region Algorithm
    #endregion Algorithm

    #region Create

    /// <summary>
    /// Standard Constructor
    /// </summary>
    public AzureImport(AzureEnterprise enterprise) {
      Enterprise = enterprise ?? throw new ArgumentNullException(nameof(enterprise));

      foreach (var user in Enterprise.Users) {
        var item = new AzureImportUser(this, user.User);

        m_Items.Add(item);

        m_Dictionary.Add(item.User.Id, item);
        m_Dictionary.Add(item.User.UserPrincipalName, item);
      }

      foreach (var item in m_Items) {
        var manager = item.SourceUser?.Manager;

        if (manager is not null)
          item.User.Manager = Find(manager.Id).User;
      }
    }

    #endregion Create

    #region Public

    /// <summary>
    /// Enterprise
    /// </summary>
    public AzureEnterprise Enterprise { get; }

    /// <summary>
    /// Graph Client
    /// </summary>
    public GraphServiceClient GraphClient => Enterprise.Connection;

    /// <summary>
    /// Items
    /// </summary>
    public IReadOnlyList<AzureImportUser> Items => m_Items;

    /// <summary>
    /// Find
    /// </summary>
    public AzureImportUser Find(string id) {
      if (string.IsNullOrEmpty(id))
        return null;

      return m_Dictionary.TryGetValue(id, out var result) ? result : null;
    }

    /// <summary>
    /// Add
    /// </summary>
    public AzureImportUser Add() {
      AzureImportUser result = new (this, new User());

      result.ImportKind = AzureImportKind.Insert;
      result.User.Id = Guid.NewGuid().ToString();

      return result;
    }

    #endregion Public
  }

}
