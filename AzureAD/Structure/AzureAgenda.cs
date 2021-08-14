using Microsoft.Graph;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAD.Structure {
  

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Azure Agenda
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public sealed class AzureAgenda {
    #region Private Data

    private List<AzureAgendaIssue> m_Items = new List<AzureAgendaIssue>();

    #endregion Private Data

    #region Algorithm

    internal void CoreAddItem(AzureAgendaIssue item) {
      if (item is null)
        return;

      m_Items.Add(item);
    }

    #endregion Algorithm

    #region Create

    /// <summary>
    /// Standard Constructor
    /// </summary>
    public AzureAgenda(AzureEnterprise enterprise) {
      Enterprise = enterprise ?? throw new ArgumentNullException(nameof(enterprise));

      foreach (var user in Enterprise.Users) {
        var issue = new AzureAgendaIssue(this, user);

        issue.Kind = AgendaKind.Garbage;
      }
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
    public GraphServiceClient GraphClient => Enterprise.GraphClient;

    /// <summary>
    /// Add New Issue
    /// </summary>
    public AzureAgendaIssue Add() => new AzureAgendaIssue(this);

    #endregion Public
  }

}
