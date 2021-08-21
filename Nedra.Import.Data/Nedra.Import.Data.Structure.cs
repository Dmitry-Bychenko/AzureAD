using AzureAD;
using AzureAD.Structure;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TinyExcelReader;

namespace Nedra.Import.Data {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// 
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public sealed class StructureImport : IReadOnlyList<StructureImportUser> {
    #region Private Data

    private readonly List<StructureImportUser> m_Items = new ();

    private AzureEnterprise m_AzureEnterprise;

    #endregion Private Data

    #region Algorithm

    private void CoreLoad() {
      foreach (var line in Excel.ReadRecords(FileName, Password)) {
        if (!Convert.ToString(line.row[15]).Contains('@'))
          continue;

        StructureImportUser user = new (this, line.row);

        m_Items.Add(user);
      }
    }

    #endregion Algorithm

    #region Create

    private StructureImport(string fileName, string password) {
      FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
      Password = password;
    }

    /// <summary>
    /// Load From File
    /// </summary>
    /// <param name="fileName">File Name</param>
    /// <param name="password">Password</param>
    /// <returns></returns>
    public static StructureImport Load(string fileName, string password) {
      StructureImport result = new (fileName, password);

      result.CoreLoad();

      return result;
    }

    #endregion Create

    #region Public

    /// <summary>
    /// Items
    /// </summary>
    public IReadOnlyList<StructureImportUser> Items => m_Items;

    /// <summary>
    /// File Name
    /// </summary>
    public string FileName { get; }

    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; }

    /// <summary>
    /// Enterprize
    /// </summary>
    public AzureEnterprise Enterprise {
      get => m_AzureEnterprise;
      set {
        if (ReferenceEquals(m_AzureEnterprise, value))
          return;

        m_AzureEnterprise = value;

        if (m_AzureEnterprise is null) {
          foreach (var item in Items) 
            item.UserPrincipalName = null;
          
          return;
        }

        Dictionary<string, AzureUser> mails = new (StringComparer.OrdinalIgnoreCase);
        HashSet<string> upns = new (StringComparer.OrdinalIgnoreCase);

        foreach (var user in Enterprise.Users) {
          mails.TryAdd(user.User.Mail, user.User);
          upns.Add(user.User.UserPrincipalName);
        }

        foreach (var item in Items) {
          if (mails.TryGetValue(item.Mail, out var u)) {
            item.Id = u.User.Id;
            item.UserPrincipalName = u.User.UserPrincipalName;
          }
          else {
            item.Id = Guid.NewGuid().ToString();

            string upn = $"{item.Mail.Substring(0, item.Mail.IndexOf('@'))}@{Enterprise.MasterDomain}";

            if (upns.Add(upn))
              item.UserPrincipalName = upn;
            else
              item.UserPrincipalName = $"{item.Id}@{Enterprise.MasterDomain}";
          }
        }
      }
    }

    #endregion Public

    #region IReadOnlyList<StructureImportUser>

    /// <summary>
    /// Count
    /// </summary>
    public int Count => m_Items.Count;

    /// <summary>
    /// Indexer
    /// </summary>
    public StructureImportUser this[int index] => m_Items[index];

    /// <summary>
    /// Typed Enumerator
    /// </summary>
    public IEnumerator<StructureImportUser> GetEnumerator() => m_Items.GetEnumerator();

    /// <summary>
    /// Typeless Enumerator
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    #endregion IReadOnlyList<StructureImportUser>
  }

}
