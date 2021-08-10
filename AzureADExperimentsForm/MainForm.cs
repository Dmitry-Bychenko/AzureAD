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

      return m_Connection is not null && m_Connection.IsConnected;
    }

    private void CoreRun() {
      if (!CoreConnect()) {
        rtbMain.Text = "Not Connected...";

        return;
      }

      rtbMain.Text = "Connected";
    }

    #endregion Algorithm

    #region Create

    public MainForm() {
      InitializeComponent();
    }

    #endregion Create

    private void btnRun_Click(object sender, EventArgs e) {
      CoreRun();
    }

    private void btnAzure_Click(object sender, EventArgs e) {
      AzureADConnection.ShowAzurePortal();
    }

    private void btnGraph_Click(object sender, EventArgs e) {
      AzureADConnection.ShowExplorer();
    }
  }
}
