
namespace AzureADExperimentsForm {
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
      this.rtbMain = new System.Windows.Forms.RichTextBox();
      this.btnRun = new System.Windows.Forms.Button();
      this.btnGraph = new System.Windows.Forms.Button();
      this.btnAzure = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // rtbMain
      // 
      this.rtbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rtbMain.BackColor = System.Drawing.SystemColors.Info;
      this.rtbMain.DetectUrls = false;
      this.rtbMain.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.rtbMain.HideSelection = false;
      this.rtbMain.Location = new System.Drawing.Point(22, 26);
      this.rtbMain.Name = "rtbMain";
      this.rtbMain.ReadOnly = true;
      this.rtbMain.Size = new System.Drawing.Size(1419, 610);
      this.rtbMain.TabIndex = 0;
      this.rtbMain.Text = "";
      this.rtbMain.WordWrap = false;
      // 
      // btnRun
      // 
      this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRun.Location = new System.Drawing.Point(1253, 661);
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new System.Drawing.Size(188, 58);
      this.btnRun.TabIndex = 1;
      this.btnRun.Text = "Run";
      this.btnRun.UseVisualStyleBackColor = true;
      this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
      // 
      // btnGraph
      // 
      this.btnGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnGraph.Location = new System.Drawing.Point(22, 661);
      this.btnGraph.Name = "btnGraph";
      this.btnGraph.Size = new System.Drawing.Size(188, 58);
      this.btnGraph.TabIndex = 2;
      this.btnGraph.Text = "Graph";
      this.btnGraph.UseVisualStyleBackColor = true;
      this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
      // 
      // btnAzure
      // 
      this.btnAzure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnAzure.Location = new System.Drawing.Point(226, 661);
      this.btnAzure.Name = "btnAzure";
      this.btnAzure.Size = new System.Drawing.Size(188, 58);
      this.btnAzure.TabIndex = 3;
      this.btnAzure.Text = "Azure";
      this.btnAzure.UseVisualStyleBackColor = true;
      this.btnAzure.Click += new System.EventHandler(this.btnAzure_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1468, 741);
      this.Controls.Add(this.btnAzure);
      this.Controls.Add(this.btnGraph);
      this.Controls.Add(this.btnRun);
      this.Controls.Add(this.rtbMain);
      this.Name = "MainForm";
      this.Text = "AzureAD Experiments";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.RichTextBox rtbMain;
    private System.Windows.Forms.Button btnRun;
    private System.Windows.Forms.Button btnGraph;
    private System.Windows.Forms.Button btnAzure;
  }
}

