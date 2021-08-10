using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureAD.WinForms {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Azure Active Directory Connection
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public partial class AzureADConnectionForm : Form {
    #region Private Data

    #endregion Private Data

    #region Algorithm

    private async Task<bool> TryConnect() {
      if (!Guid.TryParse(tbApplication.Text, out var _guid)) {
        tcMain.SelectedTab = tpDetails;

        if (tbApplication.CanFocus)
          tbApplication.Focus();

        MessageBox.Show("Application Id is invalid", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        
        return false;
      }

      Connection = new AzureADConnection(
        tbApplication.Text, Permissions, tbTenantId.Text, tbLogin.Text, tbPassword.Text);

      await Connection.Connect();

      return Connection.IsConnected;
    }

    #endregion Algorithm

    #region Create

    /// <summary>
    /// Standard Constructor
    /// </summary>
    private AzureADConnectionForm() {
      InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <param name="tenant"></param>
    /// <param name="permissions"></param>
    public AzureADConnectionForm(string application,
                                 string login,
                                 string password,
                                 string tenant,
                                 IEnumerable<string> permissions)
      : this() {

      tbApplication.Text = application?.Trim() ?? "";
      tbLogin.Text = login?.Trim() ?? "";
      tbPassword.Text = password?.Trim() ?? "";
      tbTenantId.Text = tenant?.Trim() ?? "";

      permissions ??= new string[] { "User.ReadBasic.All", "User.Read" };

      Permissions = permissions
        .Where(item => !string.IsNullOrWhiteSpace(item))
        .Select(item => item.Trim())
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .OrderBy(item => item, StringComparer.OrdinalIgnoreCase)
        .ToList();

      rtbPermissions.Text = string.Join(Environment.NewLine, Permissions);
    }

    #endregion Create

    #region Public

    /// <summary>
    /// Connection
    /// </summary>
    public AzureADConnection Connection { get; private set; }

    /// <summary>
    /// Permissions
    /// </summary>
    public IReadOnlyList<string> Permissions { get; }

    /// <summary>
    /// ApplicationId
    /// </summary>
    public string ApplicationId => tbApplication.Text?.Trim();

    #endregion Public

    private void btnCancel_Click(object sender, EventArgs e) {
      Close();
    }

    private void AzureADConnectionForm_Load(object sender, EventArgs e) {

    }

    private async void btnOK_Click(object sender, EventArgs e) {
      Cursor saved = Cursor;

      try {
        Cursor = Cursors.WaitCursor;

        if (await TryConnect())
          DialogResult = DialogResult.OK;
      }
      finally {
        Cursor = saved;
      }
    }

    private void AzureADConnectionForm_FormClosed(object sender, FormClosedEventArgs e) {
      Connection ??= new AzureADConnection(
        tbApplication.Text, Permissions, tbTenantId.Text, tbLogin.Text, tbPassword.Text);
    }

    private void btnPortal_Click(object sender, EventArgs e) {
      using (System.Diagnostics.Process.Start(new ProcessStartInfo {
        FileName = @"https://azure.microsoft.com/features/azure-portal/",
        UseShellExecute = true
      })) { }
    }

    private void btnShowHide_Click(object sender, EventArgs e) {
      tbPassword.PasswordChar = tbPassword.PasswordChar != '\0'
        ? '\0'
        : '⁕';
    }
  }

}
