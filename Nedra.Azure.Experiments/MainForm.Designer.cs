
namespace Nedra.Azure.Experiments {
  partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.tcMain = new System.Windows.Forms.TabControl();
      this.tpConnect = new System.Windows.Forms.TabPage();
      this.tpPerform = new System.Windows.Forms.TabPage();
      this.tbTeam = new System.Windows.Forms.TextBox();
      this.lbTeam = new System.Windows.Forms.Label();
      this.rtbBearier = new System.Windows.Forms.RichTextBox();
      this.lbBearier = new System.Windows.Forms.Label();
      this.lbPermissions = new System.Windows.Forms.Label();
      this.tbPermissions = new System.Windows.Forms.TextBox();
      this.tbPassword = new System.Windows.Forms.TextBox();
      this.tbLogin = new System.Windows.Forms.TextBox();
      this.tbApplication = new System.Windows.Forms.TextBox();
      this.tbTenant = new System.Windows.Forms.TextBox();
      this.lbPassword = new System.Windows.Forms.Label();
      this.lbLogin = new System.Windows.Forms.Label();
      this.lbApplication = new System.Windows.Forms.Label();
      this.lbTenant = new System.Windows.Forms.Label();
      this.ssMain = new System.Windows.Forms.StatusStrip();
      this.tssState = new System.Windows.Forms.ToolStripStatusLabel();
      this.tcMain.SuspendLayout();
      this.tpConnect.SuspendLayout();
      this.ssMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // tcMain
      // 
      this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tcMain.Controls.Add(this.tpConnect);
      this.tcMain.Controls.Add(this.tpPerform);
      this.tcMain.Location = new System.Drawing.Point(12, 26);
      this.tcMain.Name = "tcMain";
      this.tcMain.SelectedIndex = 0;
      this.tcMain.Size = new System.Drawing.Size(1995, 981);
      this.tcMain.TabIndex = 0;
      // 
      // tpConnect
      // 
      this.tpConnect.BackColor = System.Drawing.SystemColors.Control;
      this.tpConnect.Controls.Add(this.tbTeam);
      this.tpConnect.Controls.Add(this.lbTeam);
      this.tpConnect.Controls.Add(this.rtbBearier);
      this.tpConnect.Controls.Add(this.lbBearier);
      this.tpConnect.Controls.Add(this.lbPermissions);
      this.tpConnect.Controls.Add(this.tbPermissions);
      this.tpConnect.Controls.Add(this.tbPassword);
      this.tpConnect.Controls.Add(this.tbLogin);
      this.tpConnect.Controls.Add(this.tbApplication);
      this.tpConnect.Controls.Add(this.tbTenant);
      this.tpConnect.Controls.Add(this.lbPassword);
      this.tpConnect.Controls.Add(this.lbLogin);
      this.tpConnect.Controls.Add(this.lbApplication);
      this.tpConnect.Controls.Add(this.lbTenant);
      this.tpConnect.Location = new System.Drawing.Point(10, 58);
      this.tpConnect.Name = "tpConnect";
      this.tpConnect.Padding = new System.Windows.Forms.Padding(3);
      this.tpConnect.Size = new System.Drawing.Size(1975, 913);
      this.tpConnect.TabIndex = 0;
      this.tpConnect.Text = "Connect";
      // 
      // tpPerform
      // 
      this.tpPerform.BackColor = System.Drawing.SystemColors.Control;
      this.tpPerform.Location = new System.Drawing.Point(10, 58);
      this.tpPerform.Name = "tpPerform";
      this.tpPerform.Padding = new System.Windows.Forms.Padding(3);
      this.tpPerform.Size = new System.Drawing.Size(1975, 913);
      this.tpPerform.TabIndex = 1;
      this.tpPerform.Text = "Perform";
      // 
      // tbTeam
      // 
      this.tbTeam.Location = new System.Drawing.Point(23, 657);
      this.tbTeam.Name = "tbTeam";
      this.tbTeam.Size = new System.Drawing.Size(639, 47);
      this.tbTeam.TabIndex = 27;
      this.tbTeam.Text = "7bfa1540-d2c6-467b-a882-c3006a05434a";
      // 
      // lbTeam
      // 
      this.lbTeam.AutoSize = true;
      this.lbTeam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbTeam.Location = new System.Drawing.Point(23, 596);
      this.lbTeam.Name = "lbTeam";
      this.lbTeam.Size = new System.Drawing.Size(92, 41);
      this.lbTeam.TabIndex = 26;
      this.lbTeam.Text = "Team";
      // 
      // rtbBearier
      // 
      this.rtbBearier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rtbBearier.BackColor = System.Drawing.SystemColors.Info;
      this.rtbBearier.DetectUrls = false;
      this.rtbBearier.HideSelection = false;
      this.rtbBearier.Location = new System.Drawing.Point(742, 668);
      this.rtbBearier.Name = "rtbBearier";
      this.rtbBearier.ReadOnly = true;
      this.rtbBearier.Size = new System.Drawing.Size(1196, 204);
      this.rtbBearier.TabIndex = 25;
      this.rtbBearier.Text = "";
      // 
      // lbBearier
      // 
      this.lbBearier.AutoSize = true;
      this.lbBearier.Location = new System.Drawing.Point(742, 596);
      this.lbBearier.Name = "lbBearier";
      this.lbBearier.Size = new System.Drawing.Size(109, 41);
      this.lbBearier.TabIndex = 24;
      this.lbBearier.Text = "Bearier";
      // 
      // lbPermissions
      // 
      this.lbPermissions.AutoSize = true;
      this.lbPermissions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbPermissions.Location = new System.Drawing.Point(742, 32);
      this.lbPermissions.Name = "lbPermissions";
      this.lbPermissions.Size = new System.Drawing.Size(183, 41);
      this.lbPermissions.TabIndex = 23;
      this.lbPermissions.Text = "Permissions";
      // 
      // tbPermissions
      // 
      this.tbPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbPermissions.Location = new System.Drawing.Point(742, 99);
      this.tbPermissions.Multiline = true;
      this.tbPermissions.Name = "tbPermissions";
      this.tbPermissions.Size = new System.Drawing.Size(1196, 465);
      this.tbPermissions.TabIndex = 22;
      this.tbPermissions.Text = "User.ReadBasic.All\r\nUser.Read\r\nUser.Read.All\r\nUser.ReadWrite.All\r\nFiles.Read\r\nFil" +
    "es.ReadWrite\r\nFiles.ReadWrite.AppFolder";
      this.tbPermissions.WordWrap = false;
      // 
      // tbPassword
      // 
      this.tbPassword.Location = new System.Drawing.Point(23, 517);
      this.tbPassword.Name = "tbPassword";
      this.tbPassword.PasswordChar = '*';
      this.tbPassword.Size = new System.Drawing.Size(639, 47);
      this.tbPassword.TabIndex = 21;
      this.tbPassword.Text = "Har15204";
      // 
      // tbLogin
      // 
      this.tbLogin.Location = new System.Drawing.Point(23, 377);
      this.tbLogin.Name = "tbLogin";
      this.tbLogin.Size = new System.Drawing.Size(639, 47);
      this.tbLogin.TabIndex = 20;
      this.tbLogin.Text = "sync_aad_1c@nedra.digital";
      // 
      // tbApplication
      // 
      this.tbApplication.Location = new System.Drawing.Point(23, 237);
      this.tbApplication.Name = "tbApplication";
      this.tbApplication.Size = new System.Drawing.Size(639, 47);
      this.tbApplication.TabIndex = 19;
      this.tbApplication.Text = "1e89239e-277a-4da0-b740-df3caa5f1722";
      // 
      // tbTenant
      // 
      this.tbTenant.Location = new System.Drawing.Point(23, 97);
      this.tbTenant.Name = "tbTenant";
      this.tbTenant.Size = new System.Drawing.Size(639, 47);
      this.tbTenant.TabIndex = 18;
      this.tbTenant.Text = "1b4a1891-24bd-451e-8548-48986af6f553";
      // 
      // lbPassword
      // 
      this.lbPassword.AutoSize = true;
      this.lbPassword.Location = new System.Drawing.Point(23, 452);
      this.lbPassword.Name = "lbPassword";
      this.lbPassword.Size = new System.Drawing.Size(143, 41);
      this.lbPassword.TabIndex = 17;
      this.lbPassword.Text = "Password";
      // 
      // lbLogin
      // 
      this.lbLogin.AutoSize = true;
      this.lbLogin.Location = new System.Drawing.Point(23, 314);
      this.lbLogin.Name = "lbLogin";
      this.lbLogin.Size = new System.Drawing.Size(78, 41);
      this.lbLogin.TabIndex = 16;
      this.lbLogin.Text = "User";
      // 
      // lbApplication
      // 
      this.lbApplication.AutoSize = true;
      this.lbApplication.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbApplication.Location = new System.Drawing.Point(23, 172);
      this.lbApplication.Name = "lbApplication";
      this.lbApplication.Size = new System.Drawing.Size(182, 41);
      this.lbApplication.TabIndex = 15;
      this.lbApplication.Text = "Application";
      // 
      // lbTenant
      // 
      this.lbTenant.AutoSize = true;
      this.lbTenant.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbTenant.Location = new System.Drawing.Point(23, 32);
      this.lbTenant.Name = "lbTenant";
      this.lbTenant.Size = new System.Drawing.Size(113, 41);
      this.lbTenant.TabIndex = 14;
      this.lbTenant.Text = "Tenant";
      // 
      // ssMain
      // 
      this.ssMain.ImageScalingSize = new System.Drawing.Size(40, 40);
      this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssState});
      this.ssMain.Location = new System.Drawing.Point(0, 1060);
      this.ssMain.Name = "ssMain";
      this.ssMain.Size = new System.Drawing.Size(2019, 48);
      this.ssMain.TabIndex = 4;
      this.ssMain.Text = "statusStrip1";
      // 
      // tssState
      // 
      this.tssState.Name = "tssState";
      this.tssState.Size = new System.Drawing.Size(0, 35);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(2019, 1108);
      this.Controls.Add(this.ssMain);
      this.Controls.Add(this.tcMain);
      this.Name = "MainForm";
      this.Text = "MainForm";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.tcMain.ResumeLayout(false);
      this.tpConnect.ResumeLayout(false);
      this.tpConnect.PerformLayout();
      this.ssMain.ResumeLayout(false);
      this.ssMain.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tcMain;
    private System.Windows.Forms.TabPage tpConnect;
    private System.Windows.Forms.TabPage tpPerform;
    private System.Windows.Forms.TextBox tbTeam;
    private System.Windows.Forms.Label lbTeam;
    private System.Windows.Forms.RichTextBox rtbBearier;
    private System.Windows.Forms.Label lbBearier;
    private System.Windows.Forms.Label lbPermissions;
    private System.Windows.Forms.TextBox tbPermissions;
    private System.Windows.Forms.TextBox tbPassword;
    private System.Windows.Forms.TextBox tbLogin;
    private System.Windows.Forms.TextBox tbApplication;
    private System.Windows.Forms.TextBox tbTenant;
    private System.Windows.Forms.Label lbPassword;
    private System.Windows.Forms.Label lbLogin;
    private System.Windows.Forms.Label lbApplication;
    private System.Windows.Forms.Label lbTenant;
    private System.Windows.Forms.StatusStrip ssMain;
    private System.Windows.Forms.ToolStripStatusLabel tssState;
  }
}