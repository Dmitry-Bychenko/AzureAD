using AzureAD;
using AzureAD.Structure;
using AzureAD.WinForms;

using Nedra.Birthdays.BusinessLogic;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nedra.Birthdays {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Main Form As it is
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public partial class MainForm : Form {
    #region Constants

    private const string EXTENSION_NAME = "Nedra.HR.Birthday";

    private const string DIRECTORY_NAME = "Birthday Greetings"; 

    #endregion Constants

    #region Private Data

    private readonly WebBrowser wbGreeting = new ();
    private readonly WebBrowser wbBirthday = new ();

    #endregion Private Data

    #region Algorithm

    #region UI

    private void CoreBuildUI() {
      wbGreeting.Location = new Point(dgvGreetings.Location.X + dgvGreetings.Width + 20, dgvGreetings.Location.Y);
      wbGreeting.Size = new Size(tpGreetings.ClientSize.Width - wbGreeting.Location.X - 20, dgvGreetings.Height);

      wbGreeting.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

      wbGreeting.Parent = tpGreetings;

      wbBirthday.Location = new Point(cbBirthdayFile.Left, cbBirthdayFile.Top + cbBirthdayFile.Height + 20);
      wbBirthday.Size = new Size(cbBirthdayFile.Width, spltMain.Panel2.Height - 20 - wbBirthday.Top);
      wbBirthday.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      wbBirthday.Parent = spltMain.Panel2;

      dtpFrom.Value = DateTime.Today;

      if (dtpFrom.Value.DayOfWeek == DayOfWeek.Friday)
        dtpFrom.Value = dtpFrom.Value.AddDays(2);
      else if (dtpFrom.Value.DayOfWeek == DayOfWeek.Saturday)
        dtpFrom.Value = dtpFrom.Value.AddDays(1);
      else
        dtpFrom.Value = dtpFrom.Value;

      FormRoutine.ApplyGridUI(dgvBirthday);
      FormRoutine.ApplyGridUI(dgvEmployees);
      FormRoutine.ApplyGridUI(dgvGreetings);
    }

    private void CoreUpdateUI() {
      btnConnect.Enabled = Enterprise is null;

      rtbBearier.Text = Enterprise?.Connection?.Bearer ?? "";

      btnAddGreeting.Enabled = Enterprise is not null;
      btnRemoveGreeting.Enabled = (Enterprise is not null) && dgvGreetings.Rows.Count > 0;
    }

    private async Task CoreUpdateHtmlGreeting() {
      wbBirthday.DocumentText = "";

      if (Enterprise is null)
        return;

      if (dgvGreetings.CurrentCell is null)
        return;

      if (dgvGreetings.Rows.Count <= 0) 
        return;

      string fileName = (dgvGreetings.CurrentCell.Value as string);

      if (string.IsNullOrEmpty(fileName))
        return;

      var data = await Enterprise.Me.ReadFile(Path.Combine(DIRECTORY_NAME, fileName));

      var text = Encoding.UTF8.GetString(data);

      wbGreeting.DocumentText = text;
    }

    #endregion UI

    #region Business Logic

    private async Task CoreConnect() {
      if (Enterprise is not null)
        return;

      tssState.Text = "Connecting...";

      Enterprise = await AzureADEnterpriseController.LoadAsync(
        tbApplication.Text,
        tbLogin.Text,
        tbPassword.Text,
        tbTenant.Text,
        tbPermissions.Text.Split(new char[] { ' ', '\r', '\n', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries));

      tssState.Text = Enterprise is not null ? "Connected and Loaded" : "Not Connected";

      CoreUpdateUI();

      await CoreLoadGreetings();

      CoreLoadEmployee();
    }

    private async Task<bool> CoreAddGreeting() {
      if (Enterprise is null)
        return false;
      
      if (ofdHtml.ShowDialog() != DialogResult.OK)
        return false;

      string fileName = Path.GetFileName(ofdHtml.FileName);

      for (int row = 0; row < dgvGreetings.Rows.Count; ++row) 
        if (object.Equals(dgvGreetings.Rows[row].Cells[0].Value, fileName)) 
          return false;

      byte[] data = File.ReadAllBytes(ofdHtml.FileName);

      await Enterprise.Me.WriteFile(Path.Combine(DIRECTORY_NAME, fileName), data);

      int rowIndex = dgvGreetings.Rows.Add();

      dgvGreetings.Rows[rowIndex].Cells[0].Value = fileName;

      dgvGreetings.Sort(FormRoutine.ColumnComparer);

      for (int row = 0; row < dgvGreetings.Rows.Count; ++row) {
        if (object.Equals(dgvGreetings.Rows[row].Cells[0].Value, fileName)) {
          dgvGreetings.CurrentCell = dgvGreetings.Rows[row].Cells[0];

          break;
        }
      }

      clbGreetings.Items.Add(fileName);

      CoreUpdateUI();

      return true;
    }

    private async Task<bool> CoreDeleteGreeting() {
      if (Enterprise is null)
        return false;

      if (dgvGreetings.Rows.Count <= 0)
        return false;

      if (dgvGreetings.CurrentCell is null)
        return false;
      
      string fileName = dgvGreetings.Rows[dgvGreetings.CurrentCell.RowIndex].Cells[0].Value?.ToString();

      if (!FormRoutine.AskQuestion($"Do you want to delete {fileName} file?"))
        return false;

      string file = Path.Combine(DIRECTORY_NAME, fileName);

      await Enterprise.Me.DeleteFileOrDirectory(file);

      dgvGreetings.Rows.RemoveAt(dgvGreetings.CurrentCell.RowIndex);

      clbGreetings.Items.Remove(fileName);
      CoreUpdateUI();

      await CoreUpdateHtmlGreeting();

      return true;
    }

    private async Task CoreLoadGreetings() {
      if (Enterprise is null)
        return;

      List<string> files = new ();

      HashSet<string> knownExtensions = new(StringComparer.OrdinalIgnoreCase) {
        ".htm",
        ".html",
      };

      await foreach (string file in Enterprise.Me.EnumerateFiles("Birthday Greetings")) 
        if (knownExtensions.Contains(Path.GetExtension(file)))
          files.Add(file);

      var data = files
        .OrderBy(item => item, StringComparer.OrdinalIgnoreCase);

      foreach (string file in data) {
        int row = dgvGreetings.Rows.Add();

        dgvGreetings.Rows[row].Cells[0].Value = file;
      }

      CoreUpdateUI();

      await CoreUpdateHtmlGreeting();
    }
       
    private void CoreLoadEmployee() {
      if (Enterprise is null)
        return;
      
      var users = Enterprise
        .Users
        .Where(user => user.User.EmployeeHireDate is not null)
        .OrderBy(user => user.User.DisplayName);
      
      foreach (var user in users) {
        int row = dgvEmployees.Rows.Add();

        dgvEmployees.Rows[row].Cells[0].Value = user;
        dgvEmployees.Rows[row].Cells[1].Value = user.User.DisplayName;

        DateTime? dt = user.GetBirthday();

        dgvEmployees.Rows[row].Cells[2].Value = dt.HasValue
          ? dt.Value.ToString("d MMMM yyyy")
          : "";

        string[] files = user.GetGreetings() ?? Array.Empty<string>();

        dgvEmployees.Rows[row].Cells[3].Value = string.Join(", ",
          files.Distinct().OrderBy(file => file, StringComparer.OrdinalIgnoreCase));
      }
    }

    #endregion Business Logic

    #endregion Algorithm

    #region Create

    /// <summary>
    /// Constructor
    /// </summary>
    public MainForm() {
      InitializeComponent();
    }

    #endregion Create

    #region Public

    /// <summary>
    /// Enterprise
    /// </summary>
    public AzureEnterprise Enterprise { get; private set; }

    #endregion Public

    private void btnPortal_Click(object sender, EventArgs e) {
      AzureADConnection.ShowAzurePortal();
    }

    private void btnExplorer_Click(object sender, EventArgs e) {
      AzureADConnection.ShowExplorer();
    }

    private async void MainForm_Load(object sender, EventArgs e) {
      CoreBuildUI();
      CoreUpdateUI();

      await CoreConnect();
    }

    private async void btnConnect_Click(object sender, EventArgs e) {
      await CoreConnect();
    }

    private async void dgvGreetings_SelectionChanged(object sender, EventArgs e) {
      await CoreUpdateHtmlGreeting();
    }

    private async void btnAddGreeting_Click(object sender, EventArgs e) {
      await CoreAddGreeting();
    }

    private async void btnRemoveGreeting_Click(object sender, EventArgs e) {
      await CoreDeleteGreeting();
    }
  }
}
