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

    private bool CoreConnect() {
      if (m_Connection is not null && m_Connection.IsConnected)
        return true;

      m_Connection = AzureADConnectionController.Connect(
        "d2d7067e-15ac-4f1e-8130-75bc4a6ce717",
        "sync_aad_1c@nedra.digital",
        "Har15204",
        "1b4a1891-24bd-451e-8548-48986af6f553", 
        new string[] { });

      if (m_Connection is null || !m_Connection.IsConnected)
        return false;

      lbProgress.Text = "Loading...";
      lbProgress.Visible = true;

      m_EnterpriseTask = AzureEnterprise.Create(m_Connection);

      return true;
    }

    private async Task CoreRun() {
      if (!CoreConnect()) {
        rtbMain.Text = "Not Connected...";

        return;
      }

      m_Enterpise = await m_EnterpriseTask;

      lbProgress.Visible = false;

      rtbMain.Text = "Connected & Loaded";

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
