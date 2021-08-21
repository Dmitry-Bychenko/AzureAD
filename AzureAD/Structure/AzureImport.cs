using Microsoft.Graph;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    /// <summary>
    /// Remove 
    /// </summary>
    public bool Remove(AzureImportUser user) {
      if (user is null)
        return false;

      if (user.User is not null) {
        m_Dictionary.Remove(user.User.Id);
        m_Dictionary.Remove(user.User.UserPrincipalName);
      }

      bool result = false;

      for (int i = m_Items.Count - 1; i >= 0; --i)
        if (m_Items[i] == user) {
          result = true;

          break;
        }

      return result;
    }

    /// <summary>
    /// Perform
    /// </summary>
    public async Task Perform() {
      foreach (var item in Items) 
        await item.CorePerformAction();

      foreach (var item in Items)
        await item.CoreManagerUpdate();
    }

    /// <summary>
    /// Perform Report
    /// </summary>
    public string Report() {
      IEnumerable<string> Section(AzureImportResult kind) {
        return Items
          .Where(item => item.LogRecord.ImportResult == kind)
          .OrderBy(item => item.ImportKind)
          .ThenBy(item => item.LogRecord.DisplayName, StringComparer.OrdinalIgnoreCase)
          .Select(item => $"    {item}");
      }

      StringBuilder sb = new ();

      sb.AppendLine("Statistics:");
      sb.AppendLine($"  Failed:  {Items.Count(item => item.LogRecord.ImportResult == AzureImportResult.Failed),4}");
      sb.AppendLine($"  Not Run: {Items.Count(item => item.LogRecord.ImportResult == AzureImportResult.NotRun),4}");
      sb.AppendLine($"  Skipped: {Items.Count(item => item.LogRecord.ImportResult == AzureImportResult.Skipped),4}");
      sb.AppendLine($"  Succeed: {Items.Count(item => item.LogRecord.ImportResult == AzureImportResult.Success),4}");
      sb.AppendLine($"  Total:   {Items.Count,4}");

      sb.AppendLine();
      sb.AppendLine("Details:");

      sb.AppendLine();
      sb.AppendLine($"  Failed ({Items.Count(item => item.LogRecord.ImportResult == AzureImportResult.Failed)}):");
      sb.AppendLine(string.Join(Environment.NewLine, Section(AzureImportResult.Failed)));

      sb.AppendLine();
      sb.AppendLine($"  Not Run ({Items.Count(item => item.LogRecord.ImportResult == AzureImportResult.NotRun)}):");
      sb.AppendLine(string.Join(Environment.NewLine, Section(AzureImportResult.NotRun)));

      sb.AppendLine();
      sb.AppendLine($"  Skipped ({Items.Count(item => item.LogRecord.ImportResult == AzureImportResult.Skipped)}):");
      sb.AppendLine(string.Join(Environment.NewLine, Section(AzureImportResult.Skipped)));
      
      sb.AppendLine();
      sb.AppendLine($"  Succeed ({Items.Count(item => item.LogRecord.ImportResult == AzureImportResult.Success)}):");
      sb.AppendLine(string.Join(Environment.NewLine, Section(AzureImportResult.Success)));

      return sb.ToString();
    }

    #endregion Public
  }

}
