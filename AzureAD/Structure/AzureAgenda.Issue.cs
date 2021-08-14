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
  
  public enum AgendaKind {
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

  public sealed class AzureAgendaIssue {
    #region Private Data
    #endregion Private Data

    #region Algorithm
    #endregion Algorithm

    #region Create

    /// <summary>
    /// 
    /// </summary>
    public AzureAgendaIssue(AzureAgenda agenda) {
      Agenda = agenda ?? throw new ArgumentNullException(nameof(agenda));

      Agenda.CoreAddItem(this);

      User = new User();
    }

    public AzureAgendaIssue(AzureAgenda agenda, AzureUser user)
      : this(agenda) {

      if (user is not null) {
        CurrentUser = user.User;

        User.Id = user.User.Id;
        User.UserPrincipalName = user.User.Id;
        User.DisplayName = user.User.DisplayName;
      }
    }

    #endregion Create

    #region Public

    /// <summary>
    /// Kind
    /// </summary>
    public AgendaKind Kind { get; set; }

    /// <summary>
    /// Agenda
    /// </summary>
    public AzureAgenda Agenda { get; }

    /// <summary>
    /// Enterprise
    /// </summary>
    public AzureEnterprise Enterprise => Agenda.Enterprise;

    /// <summary>
    /// User
    /// </summary>
    public User User { get; }

    /// <summary>
    /// Current User if any
    /// </summary>
    public User CurrentUser { get; }

    #endregion Public
  }

}
