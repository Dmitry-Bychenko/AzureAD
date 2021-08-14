
namespace Nedra.Birthdays {
  partial class MainForm {
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
      this.btnPortal = new System.Windows.Forms.Button();
      this.btnExplorer = new System.Windows.Forms.Button();
      this.btnConnect = new System.Windows.Forms.Button();
      this.ssMain = new System.Windows.Forms.StatusStrip();
      this.tssState = new System.Windows.Forms.ToolStripStatusLabel();
      this.tcMain = new System.Windows.Forms.TabControl();
      this.tpGreetings = new System.Windows.Forms.TabPage();
      this.btnRemoveGreeting = new System.Windows.Forms.Button();
      this.btnAddGreeting = new System.Windows.Forms.Button();
      this.dgvGreetings = new System.Windows.Forms.DataGridView();
      this.clmGreeting = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tpBirthdays = new System.Windows.Forms.TabPage();
      this.clbGreetings = new System.Windows.Forms.CheckedListBox();
      this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.dgvEmployees = new System.Windows.Forms.DataGridView();
      this.clmEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clmBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clmGreetings = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tpGreet = new System.Windows.Forms.TabPage();
      this.spltMain = new System.Windows.Forms.SplitContainer();
      this.dgvBirthday = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clmGreet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.clmFile = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.lbUpTo = new System.Windows.Forms.Label();
      this.dtpTo = new System.Windows.Forms.DateTimePicker();
      this.dtpFrom = new System.Windows.Forms.DateTimePicker();
      this.btnSend = new System.Windows.Forms.Button();
      this.cbBirthdayFile = new System.Windows.Forms.ComboBox();
      this.lbBirthdayDate = new System.Windows.Forms.Label();
      this.lbBirthdayDepartment = new System.Windows.Forms.Label();
      this.lbBirthdayJobTitle = new System.Windows.Forms.Label();
      this.lbBirthdayName = new System.Windows.Forms.Label();
      this.tpName = new System.Windows.Forms.TabPage();
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
      this.ofdHtml = new System.Windows.Forms.OpenFileDialog();
      this.ssMain.SuspendLayout();
      this.tcMain.SuspendLayout();
      this.tpGreetings.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvGreetings)).BeginInit();
      this.tpBirthdays.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
      this.tpGreet.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.spltMain)).BeginInit();
      this.spltMain.Panel1.SuspendLayout();
      this.spltMain.Panel2.SuspendLayout();
      this.spltMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvBirthday)).BeginInit();
      this.tpName.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnPortal
      // 
      this.btnPortal.Location = new System.Drawing.Point(243, 25);
      this.btnPortal.Name = "btnPortal";
      this.btnPortal.Size = new System.Drawing.Size(188, 58);
      this.btnPortal.TabIndex = 0;
      this.btnPortal.Text = "Portal";
      this.btnPortal.UseVisualStyleBackColor = true;
      this.btnPortal.Click += new System.EventHandler(this.btnPortal_Click);
      // 
      // btnExplorer
      // 
      this.btnExplorer.Location = new System.Drawing.Point(461, 25);
      this.btnExplorer.Name = "btnExplorer";
      this.btnExplorer.Size = new System.Drawing.Size(188, 58);
      this.btnExplorer.TabIndex = 1;
      this.btnExplorer.Text = "Explorer";
      this.btnExplorer.UseVisualStyleBackColor = true;
      this.btnExplorer.Click += new System.EventHandler(this.btnExplorer_Click);
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(24, 25);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(188, 58);
      this.btnConnect.TabIndex = 2;
      this.btnConnect.Text = "Connect...";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // ssMain
      // 
      this.ssMain.ImageScalingSize = new System.Drawing.Size(40, 40);
      this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssState});
      this.ssMain.Location = new System.Drawing.Point(0, 1084);
      this.ssMain.Name = "ssMain";
      this.ssMain.Size = new System.Drawing.Size(1897, 22);
      this.ssMain.TabIndex = 3;
      this.ssMain.Text = "statusStrip1";
      // 
      // tssState
      // 
      this.tssState.Name = "tssState";
      this.tssState.Size = new System.Drawing.Size(0, 9);
      // 
      // tcMain
      // 
      this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tcMain.Controls.Add(this.tpGreetings);
      this.tcMain.Controls.Add(this.tpBirthdays);
      this.tcMain.Controls.Add(this.tpGreet);
      this.tcMain.Controls.Add(this.tpName);
      this.tcMain.Location = new System.Drawing.Point(24, 111);
      this.tcMain.Name = "tcMain";
      this.tcMain.SelectedIndex = 0;
      this.tcMain.Size = new System.Drawing.Size(1852, 914);
      this.tcMain.TabIndex = 4;
      // 
      // tpGreetings
      // 
      this.tpGreetings.BackColor = System.Drawing.SystemColors.Control;
      this.tpGreetings.Controls.Add(this.btnRemoveGreeting);
      this.tpGreetings.Controls.Add(this.btnAddGreeting);
      this.tpGreetings.Controls.Add(this.dgvGreetings);
      this.tpGreetings.Location = new System.Drawing.Point(10, 58);
      this.tpGreetings.Name = "tpGreetings";
      this.tpGreetings.Padding = new System.Windows.Forms.Padding(3);
      this.tpGreetings.Size = new System.Drawing.Size(1832, 846);
      this.tpGreetings.TabIndex = 0;
      this.tpGreetings.Text = "Greetings";
      // 
      // btnRemoveGreeting
      // 
      this.btnRemoveGreeting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.btnRemoveGreeting.Location = new System.Drawing.Point(93, 18);
      this.btnRemoveGreeting.Name = "btnRemoveGreeting";
      this.btnRemoveGreeting.Size = new System.Drawing.Size(62, 58);
      this.btnRemoveGreeting.TabIndex = 2;
      this.btnRemoveGreeting.Text = "-";
      this.btnRemoveGreeting.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.btnRemoveGreeting.UseVisualStyleBackColor = true;
      this.btnRemoveGreeting.Click += new System.EventHandler(this.btnRemoveGreeting_Click);
      // 
      // btnAddGreeting
      // 
      this.btnAddGreeting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.btnAddGreeting.Location = new System.Drawing.Point(15, 18);
      this.btnAddGreeting.Name = "btnAddGreeting";
      this.btnAddGreeting.Size = new System.Drawing.Size(61, 58);
      this.btnAddGreeting.TabIndex = 1;
      this.btnAddGreeting.Text = "+";
      this.btnAddGreeting.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.btnAddGreeting.UseVisualStyleBackColor = true;
      this.btnAddGreeting.Click += new System.EventHandler(this.btnAddGreeting_Click);
      // 
      // dgvGreetings
      // 
      this.dgvGreetings.AllowUserToAddRows = false;
      this.dgvGreetings.AllowUserToDeleteRows = false;
      this.dgvGreetings.AllowUserToOrderColumns = true;
      this.dgvGreetings.AllowUserToResizeColumns = false;
      this.dgvGreetings.AllowUserToResizeRows = false;
      this.dgvGreetings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.dgvGreetings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvGreetings.ColumnHeadersVisible = false;
      this.dgvGreetings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmGreeting});
      this.dgvGreetings.Location = new System.Drawing.Point(15, 97);
      this.dgvGreetings.MultiSelect = false;
      this.dgvGreetings.Name = "dgvGreetings";
      this.dgvGreetings.ReadOnly = true;
      this.dgvGreetings.RowHeadersVisible = false;
      this.dgvGreetings.RowHeadersWidth = 102;
      this.dgvGreetings.RowTemplate.Height = 49;
      this.dgvGreetings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvGreetings.Size = new System.Drawing.Size(600, 724);
      this.dgvGreetings.TabIndex = 0;
      this.dgvGreetings.SelectionChanged += new System.EventHandler(this.dgvGreetings_SelectionChanged);
      // 
      // clmGreeting
      // 
      this.clmGreeting.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.clmGreeting.HeaderText = "Greeting";
      this.clmGreeting.MinimumWidth = 12;
      this.clmGreeting.Name = "clmGreeting";
      this.clmGreeting.ReadOnly = true;
      this.clmGreeting.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      // 
      // tpBirthdays
      // 
      this.tpBirthdays.BackColor = System.Drawing.SystemColors.Control;
      this.tpBirthdays.Controls.Add(this.clbGreetings);
      this.tpBirthdays.Controls.Add(this.dateTimePicker1);
      this.tpBirthdays.Controls.Add(this.label4);
      this.tpBirthdays.Controls.Add(this.label3);
      this.tpBirthdays.Controls.Add(this.label2);
      this.tpBirthdays.Controls.Add(this.label1);
      this.tpBirthdays.Controls.Add(this.dgvEmployees);
      this.tpBirthdays.Location = new System.Drawing.Point(10, 58);
      this.tpBirthdays.Name = "tpBirthdays";
      this.tpBirthdays.Padding = new System.Windows.Forms.Padding(3);
      this.tpBirthdays.Size = new System.Drawing.Size(1832, 846);
      this.tpBirthdays.TabIndex = 1;
      this.tpBirthdays.Text = "Birthdays";
      // 
      // clbGreetings
      // 
      this.clbGreetings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.clbGreetings.FormattingEnabled = true;
      this.clbGreetings.IntegralHeight = false;
      this.clbGreetings.Location = new System.Drawing.Point(1312, 334);
      this.clbGreetings.Name = "clbGreetings";
      this.clbGreetings.Size = new System.Drawing.Size(500, 488);
      this.clbGreetings.TabIndex = 6;
      // 
      // dateTimePicker1
      // 
      this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.dateTimePicker1.Location = new System.Drawing.Point(1312, 263);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.ShowCheckBox = true;
      this.dateTimePicker1.Size = new System.Drawing.Size(500, 47);
      this.dateTimePicker1.TabIndex = 5;
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.Location = new System.Drawing.Point(1312, 196);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(500, 41);
      this.label4.TabIndex = 4;
      this.label4.Text = "?";
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.Location = new System.Drawing.Point(1312, 136);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(500, 41);
      this.label3.TabIndex = 3;
      this.label3.Text = "?";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.Location = new System.Drawing.Point(1312, 78);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(500, 41);
      this.label2.TabIndex = 2;
      this.label2.Text = "?";
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.Location = new System.Drawing.Point(1312, 25);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(500, 41);
      this.label1.TabIndex = 1;
      this.label1.Text = "?";
      // 
      // dgvEmployees
      // 
      this.dgvEmployees.AllowUserToAddRows = false;
      this.dgvEmployees.AllowUserToDeleteRows = false;
      this.dgvEmployees.AllowUserToResizeRows = false;
      this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmEmployee,
            this.clmName,
            this.clmBirthday,
            this.clmGreetings});
      this.dgvEmployees.Location = new System.Drawing.Point(15, 25);
      this.dgvEmployees.MultiSelect = false;
      this.dgvEmployees.Name = "dgvEmployees";
      this.dgvEmployees.RowHeadersVisible = false;
      this.dgvEmployees.RowHeadersWidth = 102;
      this.dgvEmployees.RowTemplate.Height = 49;
      this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvEmployees.Size = new System.Drawing.Size(1261, 800);
      this.dgvEmployees.TabIndex = 0;
      // 
      // clmEmployee
      // 
      this.clmEmployee.HeaderText = "Employee";
      this.clmEmployee.MinimumWidth = 12;
      this.clmEmployee.Name = "clmEmployee";
      this.clmEmployee.ReadOnly = true;
      this.clmEmployee.Visible = false;
      this.clmEmployee.Width = 250;
      // 
      // clmName
      // 
      this.clmName.HeaderText = "Employee";
      this.clmName.MinimumWidth = 12;
      this.clmName.Name = "clmName";
      this.clmName.ReadOnly = true;
      this.clmName.Width = 350;
      // 
      // clmBirthday
      // 
      this.clmBirthday.HeaderText = "Birthday";
      this.clmBirthday.MinimumWidth = 12;
      this.clmBirthday.Name = "clmBirthday";
      this.clmBirthday.ReadOnly = true;
      this.clmBirthday.Width = 300;
      // 
      // clmGreetings
      // 
      this.clmGreetings.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.clmGreetings.HeaderText = "Greetings";
      this.clmGreetings.MinimumWidth = 12;
      this.clmGreetings.Name = "clmGreetings";
      this.clmGreetings.ReadOnly = true;
      // 
      // tpGreet
      // 
      this.tpGreet.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.tpGreet.Controls.Add(this.spltMain);
      this.tpGreet.Location = new System.Drawing.Point(10, 58);
      this.tpGreet.Name = "tpGreet";
      this.tpGreet.Size = new System.Drawing.Size(1832, 846);
      this.tpGreet.TabIndex = 2;
      this.tpGreet.Text = "Congratulate";
      // 
      // spltMain
      // 
      this.spltMain.Cursor = System.Windows.Forms.Cursors.VSplit;
      this.spltMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.spltMain.Location = new System.Drawing.Point(0, 0);
      this.spltMain.Name = "spltMain";
      // 
      // spltMain.Panel1
      // 
      this.spltMain.Panel1.Controls.Add(this.dgvBirthday);
      this.spltMain.Panel1.Controls.Add(this.lbUpTo);
      this.spltMain.Panel1.Controls.Add(this.dtpTo);
      this.spltMain.Panel1.Controls.Add(this.dtpFrom);
      // 
      // spltMain.Panel2
      // 
      this.spltMain.Panel2.Controls.Add(this.btnSend);
      this.spltMain.Panel2.Controls.Add(this.cbBirthdayFile);
      this.spltMain.Panel2.Controls.Add(this.lbBirthdayDate);
      this.spltMain.Panel2.Controls.Add(this.lbBirthdayDepartment);
      this.spltMain.Panel2.Controls.Add(this.lbBirthdayJobTitle);
      this.spltMain.Panel2.Controls.Add(this.lbBirthdayName);
      this.spltMain.Size = new System.Drawing.Size(1832, 846);
      this.spltMain.SplitterDistance = 988;
      this.spltMain.SplitterWidth = 12;
      this.spltMain.TabIndex = 0;
      // 
      // dgvBirthday
      // 
      this.dgvBirthday.AllowUserToAddRows = false;
      this.dgvBirthday.AllowUserToDeleteRows = false;
      this.dgvBirthday.AllowUserToResizeRows = false;
      this.dgvBirthday.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvBirthday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvBirthday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.clmGreet,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.clmFile});
      this.dgvBirthday.Location = new System.Drawing.Point(16, 90);
      this.dgvBirthday.MultiSelect = false;
      this.dgvBirthday.Name = "dgvBirthday";
      this.dgvBirthday.RowHeadersVisible = false;
      this.dgvBirthday.RowHeadersWidth = 102;
      this.dgvBirthday.RowTemplate.Height = 49;
      this.dgvBirthday.Size = new System.Drawing.Size(955, 737);
      this.dgvBirthday.TabIndex = 3;
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.HeaderText = "Employee";
      this.dataGridViewTextBoxColumn1.MinimumWidth = 12;
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.ReadOnly = true;
      this.dataGridViewTextBoxColumn1.Visible = false;
      this.dataGridViewTextBoxColumn1.Width = 250;
      // 
      // clmGreet
      // 
      this.clmGreet.HeaderText = "";
      this.clmGreet.MinimumWidth = 12;
      this.clmGreet.Name = "clmGreet";
      this.clmGreet.Width = 40;
      // 
      // dataGridViewCheckBoxColumn1
      // 
      this.dataGridViewCheckBoxColumn1.HeaderText = "Name";
      this.dataGridViewCheckBoxColumn1.MinimumWidth = 12;
      this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
      this.dataGridViewCheckBoxColumn1.ReadOnly = true;
      this.dataGridViewCheckBoxColumn1.Width = 250;
      // 
      // dataGridViewCheckBoxColumn2
      // 
      this.dataGridViewCheckBoxColumn2.HeaderText = "Birthday";
      this.dataGridViewCheckBoxColumn2.MinimumWidth = 12;
      this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
      this.dataGridViewCheckBoxColumn2.ReadOnly = true;
      this.dataGridViewCheckBoxColumn2.Width = 350;
      // 
      // clmFile
      // 
      this.clmFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.clmFile.HeaderText = "File";
      this.clmFile.MinimumWidth = 12;
      this.clmFile.Name = "clmFile";
      this.clmFile.ReadOnly = true;
      // 
      // lbUpTo
      // 
      this.lbUpTo.AutoSize = true;
      this.lbUpTo.Font = new System.Drawing.Font("Segoe UI", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.lbUpTo.Location = new System.Drawing.Point(427, 7);
      this.lbUpTo.Name = "lbUpTo";
      this.lbUpTo.Size = new System.Drawing.Size(57, 62);
      this.lbUpTo.TabIndex = 2;
      this.lbUpTo.Text = "...";
      // 
      // dtpTo
      // 
      this.dtpTo.Location = new System.Drawing.Point(490, 19);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new System.Drawing.Size(392, 47);
      this.dtpTo.TabIndex = 1;
      // 
      // dtpFrom
      // 
      this.dtpFrom.Location = new System.Drawing.Point(16, 19);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new System.Drawing.Size(392, 47);
      this.dtpFrom.TabIndex = 0;
      // 
      // btnSend
      // 
      this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSend.Location = new System.Drawing.Point(513, 769);
      this.btnSend.Name = "btnSend";
      this.btnSend.Size = new System.Drawing.Size(272, 58);
      this.btnSend.TabIndex = 5;
      this.btnSend.Text = "Congratulate";
      this.btnSend.UseVisualStyleBackColor = true;
      this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
      // 
      // cbBirthdayFile
      // 
      this.cbBirthdayFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cbBirthdayFile.FormattingEnabled = true;
      this.cbBirthdayFile.Location = new System.Drawing.Point(29, 280);
      this.cbBirthdayFile.Name = "cbBirthdayFile";
      this.cbBirthdayFile.Size = new System.Drawing.Size(756, 49);
      this.cbBirthdayFile.TabIndex = 4;
      // 
      // lbBirthdayDate
      // 
      this.lbBirthdayDate.AutoSize = true;
      this.lbBirthdayDate.Location = new System.Drawing.Point(29, 214);
      this.lbBirthdayDate.Name = "lbBirthdayDate";
      this.lbBirthdayDate.Size = new System.Drawing.Size(31, 41);
      this.lbBirthdayDate.TabIndex = 3;
      this.lbBirthdayDate.Text = "?";
      // 
      // lbBirthdayDepartment
      // 
      this.lbBirthdayDepartment.AutoSize = true;
      this.lbBirthdayDepartment.Location = new System.Drawing.Point(29, 153);
      this.lbBirthdayDepartment.Name = "lbBirthdayDepartment";
      this.lbBirthdayDepartment.Size = new System.Drawing.Size(31, 41);
      this.lbBirthdayDepartment.TabIndex = 2;
      this.lbBirthdayDepartment.Text = "?";
      // 
      // lbBirthdayJobTitle
      // 
      this.lbBirthdayJobTitle.AutoSize = true;
      this.lbBirthdayJobTitle.Location = new System.Drawing.Point(29, 90);
      this.lbBirthdayJobTitle.Name = "lbBirthdayJobTitle";
      this.lbBirthdayJobTitle.Size = new System.Drawing.Size(31, 41);
      this.lbBirthdayJobTitle.TabIndex = 1;
      this.lbBirthdayJobTitle.Text = "?";
      // 
      // lbBirthdayName
      // 
      this.lbBirthdayName.AutoSize = true;
      this.lbBirthdayName.Location = new System.Drawing.Point(29, 28);
      this.lbBirthdayName.Name = "lbBirthdayName";
      this.lbBirthdayName.Size = new System.Drawing.Size(31, 41);
      this.lbBirthdayName.TabIndex = 0;
      this.lbBirthdayName.Text = "?";
      // 
      // tpName
      // 
      this.tpName.BackColor = System.Drawing.SystemColors.Control;
      this.tpName.Controls.Add(this.tbTeam);
      this.tpName.Controls.Add(this.lbTeam);
      this.tpName.Controls.Add(this.rtbBearier);
      this.tpName.Controls.Add(this.lbBearier);
      this.tpName.Controls.Add(this.lbPermissions);
      this.tpName.Controls.Add(this.tbPermissions);
      this.tpName.Controls.Add(this.tbPassword);
      this.tpName.Controls.Add(this.tbLogin);
      this.tpName.Controls.Add(this.tbApplication);
      this.tpName.Controls.Add(this.tbTenant);
      this.tpName.Controls.Add(this.lbPassword);
      this.tpName.Controls.Add(this.lbLogin);
      this.tpName.Controls.Add(this.lbApplication);
      this.tpName.Controls.Add(this.lbTenant);
      this.tpName.Location = new System.Drawing.Point(10, 58);
      this.tpName.Name = "tpName";
      this.tpName.Size = new System.Drawing.Size(1832, 846);
      this.tpName.TabIndex = 3;
      this.tpName.Text = "Settings";
      // 
      // tbTeam
      // 
      this.tbTeam.Location = new System.Drawing.Point(22, 650);
      this.tbTeam.Name = "tbTeam";
      this.tbTeam.Size = new System.Drawing.Size(639, 47);
      this.tbTeam.TabIndex = 13;
      this.tbTeam.Text = "7bfa1540-d2c6-467b-a882-c3006a05434a";
      // 
      // lbTeam
      // 
      this.lbTeam.AutoSize = true;
      this.lbTeam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbTeam.Location = new System.Drawing.Point(22, 589);
      this.lbTeam.Name = "lbTeam";
      this.lbTeam.Size = new System.Drawing.Size(92, 41);
      this.lbTeam.TabIndex = 12;
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
      this.rtbBearier.Location = new System.Drawing.Point(741, 661);
      this.rtbBearier.Name = "rtbBearier";
      this.rtbBearier.ReadOnly = true;
      this.rtbBearier.Size = new System.Drawing.Size(1068, 159);
      this.rtbBearier.TabIndex = 11;
      this.rtbBearier.Text = "";
      // 
      // lbBearier
      // 
      this.lbBearier.AutoSize = true;
      this.lbBearier.Location = new System.Drawing.Point(741, 589);
      this.lbBearier.Name = "lbBearier";
      this.lbBearier.Size = new System.Drawing.Size(109, 41);
      this.lbBearier.TabIndex = 10;
      this.lbBearier.Text = "Bearier";
      // 
      // lbPermissions
      // 
      this.lbPermissions.AutoSize = true;
      this.lbPermissions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbPermissions.Location = new System.Drawing.Point(741, 25);
      this.lbPermissions.Name = "lbPermissions";
      this.lbPermissions.Size = new System.Drawing.Size(183, 41);
      this.lbPermissions.TabIndex = 9;
      this.lbPermissions.Text = "Permissions";
      // 
      // tbPermissions
      // 
      this.tbPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbPermissions.Location = new System.Drawing.Point(741, 92);
      this.tbPermissions.Multiline = true;
      this.tbPermissions.Name = "tbPermissions";
      this.tbPermissions.Size = new System.Drawing.Size(1068, 465);
      this.tbPermissions.TabIndex = 8;
      this.tbPermissions.Text = "User.ReadBasic.All\r\nUser.Read\r\nUser.Read.All\r\nUser.ReadWrite.All\r\nFiles.Read\r\nFil" +
    "es.ReadWrite\r\nFiles.ReadWrite.AppFolder";
      this.tbPermissions.WordWrap = false;
      // 
      // tbPassword
      // 
      this.tbPassword.Location = new System.Drawing.Point(22, 510);
      this.tbPassword.Name = "tbPassword";
      this.tbPassword.PasswordChar = '*';
      this.tbPassword.Size = new System.Drawing.Size(639, 47);
      this.tbPassword.TabIndex = 7;
      this.tbPassword.Text = "Har15204";
      // 
      // tbLogin
      // 
      this.tbLogin.Location = new System.Drawing.Point(22, 370);
      this.tbLogin.Name = "tbLogin";
      this.tbLogin.Size = new System.Drawing.Size(639, 47);
      this.tbLogin.TabIndex = 6;
      this.tbLogin.Text = "sync_aad_1c@nedra.digital";
      // 
      // tbApplication
      // 
      this.tbApplication.Location = new System.Drawing.Point(22, 230);
      this.tbApplication.Name = "tbApplication";
      this.tbApplication.Size = new System.Drawing.Size(639, 47);
      this.tbApplication.TabIndex = 5;
      this.tbApplication.Text = "1e89239e-277a-4da0-b740-df3caa5f1722";
      // 
      // tbTenant
      // 
      this.tbTenant.Location = new System.Drawing.Point(22, 90);
      this.tbTenant.Name = "tbTenant";
      this.tbTenant.Size = new System.Drawing.Size(639, 47);
      this.tbTenant.TabIndex = 4;
      this.tbTenant.Text = "1b4a1891-24bd-451e-8548-48986af6f553";
      // 
      // lbPassword
      // 
      this.lbPassword.AutoSize = true;
      this.lbPassword.Location = new System.Drawing.Point(22, 445);
      this.lbPassword.Name = "lbPassword";
      this.lbPassword.Size = new System.Drawing.Size(143, 41);
      this.lbPassword.TabIndex = 3;
      this.lbPassword.Text = "Password";
      // 
      // lbLogin
      // 
      this.lbLogin.AutoSize = true;
      this.lbLogin.Location = new System.Drawing.Point(22, 307);
      this.lbLogin.Name = "lbLogin";
      this.lbLogin.Size = new System.Drawing.Size(78, 41);
      this.lbLogin.TabIndex = 2;
      this.lbLogin.Text = "User";
      // 
      // lbApplication
      // 
      this.lbApplication.AutoSize = true;
      this.lbApplication.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbApplication.Location = new System.Drawing.Point(22, 165);
      this.lbApplication.Name = "lbApplication";
      this.lbApplication.Size = new System.Drawing.Size(182, 41);
      this.lbApplication.TabIndex = 1;
      this.lbApplication.Text = "Application";
      // 
      // lbTenant
      // 
      this.lbTenant.AutoSize = true;
      this.lbTenant.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lbTenant.Location = new System.Drawing.Point(22, 25);
      this.lbTenant.Name = "lbTenant";
      this.lbTenant.Size = new System.Drawing.Size(113, 41);
      this.lbTenant.TabIndex = 0;
      this.lbTenant.Text = "Tenant";
      // 
      // ofdHtml
      // 
      this.ofdHtml.DefaultExt = "html";
      this.ofdHtml.Filter = "Html files (*.html)|*.html|Html files (*.htm)|*.htm";
      this.ofdHtml.FilterIndex = 0;
      this.ofdHtml.ShowReadOnly = true;
      this.ofdHtml.Title = "Files with Greetings";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1897, 1106);
      this.Controls.Add(this.tcMain);
      this.Controls.Add(this.ssMain);
      this.Controls.Add(this.btnConnect);
      this.Controls.Add(this.btnExplorer);
      this.Controls.Add(this.btnPortal);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Nedra Birthdays";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.ssMain.ResumeLayout(false);
      this.ssMain.PerformLayout();
      this.tcMain.ResumeLayout(false);
      this.tpGreetings.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvGreetings)).EndInit();
      this.tpBirthdays.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
      this.tpGreet.ResumeLayout(false);
      this.spltMain.Panel1.ResumeLayout(false);
      this.spltMain.Panel1.PerformLayout();
      this.spltMain.Panel2.ResumeLayout(false);
      this.spltMain.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.spltMain)).EndInit();
      this.spltMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvBirthday)).EndInit();
      this.tpName.ResumeLayout(false);
      this.tpName.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnPortal;
    private System.Windows.Forms.Button btnExplorer;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.StatusStrip ssMain;
    private System.Windows.Forms.ToolStripStatusLabel tssState;
    private System.Windows.Forms.TabControl tcMain;
    private System.Windows.Forms.TabPage tpGreetings;
    private System.Windows.Forms.TabPage tpBirthdays;
    private System.Windows.Forms.TabPage tpGreet;
    private System.Windows.Forms.TabPage tpName;
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
    private System.Windows.Forms.Button btnRemoveGreeting;
    private System.Windows.Forms.Button btnAddGreeting;
    private System.Windows.Forms.DataGridView dgvGreetings;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmGreeting;
    private System.Windows.Forms.DataGridView dgvEmployees;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dateTimePicker1;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployee;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmBirthday;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmGreetings;
    private System.Windows.Forms.CheckedListBox clbGreetings;
    private System.Windows.Forms.SplitContainer spltMain;
    private System.Windows.Forms.Label lbUpTo;
    private System.Windows.Forms.DateTimePicker dtpTo;
    private System.Windows.Forms.DateTimePicker dtpFrom;
    private System.Windows.Forms.DataGridView dgvBirthday;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewCheckBoxColumn clmGreet;
    private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
    private System.Windows.Forms.DataGridViewCheckBoxColumn clmFile;
    private System.Windows.Forms.ComboBox cbBirthdayFile;
    private System.Windows.Forms.Label lbBirthdayDate;
    private System.Windows.Forms.Label lbBirthdayDepartment;
    private System.Windows.Forms.Label lbBirthdayJobTitle;
    private System.Windows.Forms.Label lbBirthdayName;
    private System.Windows.Forms.TextBox tbTeam;
    private System.Windows.Forms.Label lbTeam;
    private System.Windows.Forms.OpenFileDialog ofdHtml;
    private System.Windows.Forms.Button btnSend;
  }
}

