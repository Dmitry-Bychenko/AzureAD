using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AzureAD.Structure {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// 
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public enum AzureImportResult {
    NotRun = 0,
    Skipped = 1,
    Success = 2,
    Failed = 3,
  }
  
  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// 
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public sealed class AzureImportLogRecord {
    #region Private Data
    #endregion Private Data

    #region Algorithm
    #endregion Algorithm

    #region Create

    /// <summary>
    /// Standard constructor
    /// </summary>
    /// <param name="importUser"></param>
    public AzureImportLogRecord(AzureImportUser importUser) {
      ImportUser = importUser ?? throw new ArgumentNullException(nameof(importUser));
    }

    #endregion Create

    #region Public

    /// <summary>
    /// Import User
    /// </summary>
    public AzureImportUser ImportUser { get; }

    /// <summary>
    /// Import Result
    /// </summary>
    public AzureImportResult ImportResult { get; internal set; } = AzureImportResult.NotRun;

    /// <summary>
    /// Error
    /// </summary>
    public Exception Error { get; internal set; }

    /// <summary>
    /// Display Name
    /// </summary>
    public string DisplayName => ImportUser.User?.DisplayName ?? ImportUser.SourceUser?.DisplayName ?? "";

    /// <summary>
    /// To String
    /// </summary>
    public override string ToString() {
      string name = ImportUser.User?.DisplayName ?? ImportUser.SourceUser?.DisplayName ?? "";
      string action = ImportUser.ImportKind.ToString();

      string result = $"{action,8} : {ImportResult,6}";

      if (!string.IsNullOrEmpty(name))
        result += $" : {name}";

      if (Error is not null)
        result += $" : {Regex.Replace(Error.Message, @"\s+", " ").Trim()}";

      return result;
    }

    #endregion Public
  }

}
