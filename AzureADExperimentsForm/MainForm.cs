using AzureAD;
using AzureAD.Structure;
using AzureAD.WinForms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureADExperimentsForm {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// 
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public partial class MainForm : Form {
    #region Private Data

    private AzureADConnection m_Connection;

    private Task<AzureEnterprise> m_EnterpriseTask;

    private AzureEnterprise m_Enterpise;

    #endregion Private Data

    #region Algorithm

    private void CoreConnect() {
      lbProgress.Visible = true;
      lbProgress.Text = "Loading...";

      m_EnterpriseTask = AzureADEnterpriseController.LoadAsync(
        "d2d7067e-15ac-4f1e-8130-75bc4a6ce717",
        "sync_aad_1c@nedra.digital",
        "Har15204",
        "1b4a1891-24bd-451e-8548-48986af6f553", 
        new string[] { "User.Read.All" });
    }

    private async Task CoreRun() {
      CoreConnect();

      m_Enterpise = await m_EnterpriseTask;

      lbProgress.Visible = false;

      if (m_Enterpise is null) {
        rtbMain.Text = "Failed to Load";

        return;
      }

      var result = m_Enterpise
        .Users
        .Where(user => user.Manager is not null)
        .Select(user => $"{user.User.DisplayName} :: {user.Manager.User.DisplayName}");

      rtbMain.Text = string.Join(Environment.NewLine, result);
    }

    #endregion Algorithm

    #region Create

    public MainForm() {
      InitializeComponent();
    }

    #endregion Create

    private async void btnRun_Click(object sender, EventArgs e) {
      await CoreRun();
    }

    private void btnAzure_Click(object sender, EventArgs e) {
      AzureADConnection.ShowAzurePortal();
    }

    private void btnGraph_Click(object sender, EventArgs e) {
      AzureADConnection.ShowExplorer();
    }

    private void MainForm_Load(object sender, EventArgs e) {

    }
  }
}
