
namespace AzureAD.WinForms {
  partial class AzureADConnectionForm {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.tcMain = new System.Windows.Forms.TabControl();
      this.tpLoginAndPassword = new System.Windows.Forms.TabPage();
      this.tbPassword = new System.Windows.Forms.TextBox();
      this.lbPassword = new System.Windows.Forms.Label();
      this.tbLogin = new System.Windows.Forms.TextBox();
      this.lbLogin = new System.Windows.Forms.Label();
      this.tpPermissions = new System.Windows.Forms.TabPage();
      this.rtbPermissions = new System.Windows.Forms.RichTextBox();
      this.tpDetails = new System.Windows.Forms.TabPage();
      this.tbTenantId = new System.Windows.Forms.TextBox();
      this.lbTenantId = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.lbApplication = new System.Windows.Forms.Label();
      this.tbApplication = new System.Windows.Forms.TextBox();
      this.btnPortal = new System.Windows.Forms.Button();
      this.tcMain.SuspendLayout();
      this.tpLoginAndPassword.SuspendLayout();
      this.tpPermissions.SuspendLayout();
      this.tpDetails.SuspendLayout();
      this.SuspendLayout();
      // 
      // tcMain
      // 
      this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tcMain.Controls.Add(this.tpLoginAndPassword);
      this.tcMain.Controls.Add(this.tpPermissions);
      this.tcMain.Controls.Add(this.tpDetails);
      this.tcMain.Location = new System.Drawing.Point(23, 23);
      this.tcMain.Name = "tcMain";
      this.tcMain.SelectedIndex = 0;
      this.tcMain.Size = new System.Drawing.Size(734, 432);
      this.tcMain.TabIndex = 0;
      // 
      // tpLoginAndPassword
      // 
      this.tpLoginAndPassword.BackColor = System.Drawing.SystemColors.Control;
      this.tpLoginAndPassword.Controls.Add(this.tbPassword);
      this.tpLoginAndPassword.Controls.Add(this.lbPassword);
      this.tpLoginAndPassword.Controls.Add(this.tbLogin);
      this.tpLoginAndPassword.Controls.Add(this.lbLogin);
      this.tpLoginAndPassword.Location = new System.Drawing.Point(10, 58);
      this.tpLoginAndPassword.Name = "tpLoginAndPassword";
      this.tpLoginAndPassword.Padding = new System.Windows.Forms.Padding(3);
      this.tpLoginAndPassword.Size = new System.Drawing.Size(714, 364);
      this.tpLoginAndPassword.TabIndex = 0;
      this.tpLoginAndPassword.Text = "Login and Password";
      // 
      // tbPassword
      // 
      this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbPassword.Location = new System.Drawing.Point(23, 239);
      this.tbPassword.Name = "tbPassword";
      this.tbPassword.PasswordChar = '⁕';
      this.tbPassword.Size = new System.Drawing.Size(660, 47);
      this.tbPassword.TabIndex = 3;
      // 
      // lbPassword
      // 
      this.lbPassword.AutoSize = true;
      this.lbPassword.Location = new System.Drawing.Point(23, 167);
      this.lbPassword.Name = "lbPassword";
      this.lbPassword.Size = new System.Drawing.Size(143, 41);
      this.lbPassword.TabIndex = 2;
      this.lbPassword.Text = "Password";
      // 
      // tbLogin
      // 
      this.tbLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbLogin.Location = new System.Drawing.Point(23, 91);
      this.tbLogin.Name = "tbLogin";
      this.tbLogin.Size = new System.Drawing.Size(660, 47);
      this.tbLogin.TabIndex = 1;
      // 
      // lbLogin
      // 
      this.lbLogin.AutoSize = true;
      this.lbLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbLogin.Location = new System.Drawing.Point(23, 23);
      this.lbLogin.Name = "lbLogin";
      this.lbLogin.Size = new System.Drawing.Size(97, 41);
      this.lbLogin.TabIndex = 0;
      this.lbLogin.Text = "Login";
      // 
      // tpPermissions
      // 
      this.tpPermissions.BackColor = System.Drawing.SystemColors.Control;
      this.tpPermissions.Controls.Add(this.rtbPermissions);
      this.tpPermissions.Location = new System.Drawing.Point(10, 58);
      this.tpPermissions.Name = "tpPermissions";
      this.tpPermissions.Padding = new System.Windows.Forms.Padding(3);
      this.tpPermissions.Size = new System.Drawing.Size(724, 415);
      this.tpPermissions.TabIndex = 1;
      this.tpPermissions.Text = "Permissions";
      // 
      // rtbPermissions
      // 
      this.rtbPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rtbPermissions.BackColor = System.Drawing.SystemColors.Info;
      this.rtbPermissions.DetectUrls = false;
      this.rtbPermissions.HideSelection = false;
      this.rtbPermissions.Location = new System.Drawing.Point(6, 6);
      this.rtbPermissions.Name = "rtbPermissions";
      this.rtbPermissions.ReadOnly = true;
      this.rtbPermissions.Size = new System.Drawing.Size(715, 403);
      this.rtbPermissions.TabIndex = 0;
      this.rtbPermissions.Text = "";
      this.rtbPermissions.WordWrap = false;
      // 
      // tpDetails
      // 
      this.tpDetails.BackColor = System.Drawing.SystemColors.Control;
      this.tpDetails.Controls.Add(this.tbApplication);
      this.tpDetails.Controls.Add(this.lbApplication);
      this.tpDetails.Controls.Add(this.tbTenantId);
      this.tpDetails.Controls.Add(this.lbTenantId);
      this.tpDetails.Location = new System.Drawing.Point(10, 58);
      this.tpDetails.Name = "tpDetails";
      this.tpDetails.Size = new System.Drawing.Size(714, 364);
      this.tpDetails.TabIndex = 2;
      this.tpDetails.Text = "Details";
      // 
      // tbTenantId
      // 
      this.tbTenantId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTenantId.Location = new System.Drawing.Point(23, 91);
      this.tbTenantId.Name = "tbTenantId";
      this.tbTenantId.Size = new System.Drawing.Size(660, 47);
      this.tbTenantId.TabIndex = 1;
      // 
      // lbTenantId
      // 
      this.lbTenantId.AutoSize = true;
      this.lbTenantId.Location = new System.Drawing.Point(23, 23);
      this.lbTenantId.Name = "lbTenantId";
      this.lbTenantId.Size = new System.Drawing.Size(106, 41);
      this.lbTenantId.TabIndex = 0;
      this.lbTenantId.Text = "Tenant";
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.Location = new System.Drawing.Point(364, 488);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(188, 58);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.Location = new System.Drawing.Point(558, 488);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(188, 58);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // lbApplication
      // 
      this.lbApplication.AutoSize = true;
      this.lbApplication.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbApplication.Location = new System.Drawing.Point(23, 167);
      this.lbApplication.Name = "lbApplication";
      this.lbApplication.Size = new System.Drawing.Size(182, 41);
      this.lbApplication.TabIndex = 2;
      this.lbApplication.Text = "Application";
      // 
      // tbApplication
      // 
      this.tbApplication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbApplication.Location = new System.Drawing.Point(23, 239);
      this.tbApplication.Name = "tbApplication";
      this.tbApplication.Size = new System.Drawing.Size(660, 47);
      this.tbApplication.TabIndex = 3;
      // 
      // btnPortal
      // 
      this.btnPortal.Location = new System.Drawing.Point(142, 488);
      this.btnPortal.Name = "btnPortal";
      this.btnPortal.Size = new System.Drawing.Size(188, 58);
      this.btnPortal.TabIndex = 3;
      this.btnPortal.Text = "Portal";
      this.btnPortal.UseVisualStyleBackColor = true;
      this.btnPortal.Click += new System.EventHandler(this.btnPortal_Click);
      // 
      // AzureADConnectionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(768, 562);
      this.Controls.Add(this.btnPortal);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.tcMain);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(640, 600);
      this.Name = "AzureADConnectionForm";
      this.Text = "Azure Active Directory Connect";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AzureADConnectionForm_FormClosed);
      this.Load += new System.EventHandler(this.AzureADConnectionForm_Load);
      this.tcMain.ResumeLayout(false);
      this.tpLoginAndPassword.ResumeLayout(false);
      this.tpLoginAndPassword.PerformLayout();
      this.tpPermissions.ResumeLayout(false);
      this.tpDetails.ResumeLayout(false);
      this.tpDetails.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tcMain;
    private System.Windows.Forms.TabPage tpLoginAndPassword;
    private System.Windows.Forms.TabPage tpPermissions;
    private System.Windows.Forms.TabPage tpDetails;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TextBox tbPassword;
    private System.Windows.Forms.Label lbPassword;
    private System.Windows.Forms.TextBox tbLogin;
    private System.Windows.Forms.Label lbLogin;
    private System.Windows.Forms.RichTextBox rtbPermissions;
    private System.Windows.Forms.TextBox tbTenantId;
    private System.Windows.Forms.Label lbTenantId;
    private System.Windows.Forms.TextBox tbApplication;
    private System.Windows.Forms.Label lbApplication;
    private System.Windows.Forms.Button btnPortal;
  }
}

