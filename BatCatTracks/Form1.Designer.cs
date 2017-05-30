namespace BatCatTracks
{
	partial class frmBatCatTracks
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.btnGetPulls = new System.Windows.Forms.Button();
			this.tbEventsToGet = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnExport = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.ddlEventName = new System.Windows.Forms.ComboBox();
			this.ddlRate = new System.Windows.Forms.ComboBox();
			this.btnFindSeed = new System.Windows.Forms.Button();
			this.tbSeed = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbPullCount = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dgvPullList = new System.Windows.Forms.DataGridView();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.ddlPullModifier = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPullList)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(8, 6);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(1136, 724);
			this.tbOutput.TabIndex = 100;
			// 
			// btnGetPulls
			// 
			this.btnGetPulls.Location = new System.Drawing.Point(172, 14);
			this.btnGetPulls.Name = "btnGetPulls";
			this.btnGetPulls.Size = new System.Drawing.Size(75, 23);
			this.btnGetPulls.TabIndex = 3;
			this.btnGetPulls.Text = "Calculate";
			this.btnGetPulls.UseVisualStyleBackColor = true;
			this.btnGetPulls.Click += new System.EventHandler(this.btnGetPulls_Click);
			// 
			// tbEventsToGet
			// 
			this.tbEventsToGet.Location = new System.Drawing.Point(521, 43);
			this.tbEventsToGet.Name = "tbEventsToGet";
			this.tbEventsToGet.Size = new System.Drawing.Size(108, 20);
			this.tbEventsToGet.TabIndex = 0;
			this.tbEventsToGet.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(480, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Event";
			this.label1.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.ddlPullModifier);
			this.groupBox1.Controls.Add(this.btnExport);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.ddlEventName);
			this.groupBox1.Controls.Add(this.ddlRate);
			this.groupBox1.Controls.Add(this.btnFindSeed);
			this.groupBox1.Controls.Add(this.tbSeed);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbPullCount);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.dgvPullList);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btnGetPulls);
			this.groupBox1.Controls.Add(this.tbEventsToGet);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1142, 719);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Get Pulls";
			// 
			// btnExport
			// 
			this.btnExport.Enabled = false;
			this.btnExport.Location = new System.Drawing.Point(253, 14);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(75, 23);
			this.btnExport.TabIndex = 107;
			this.btnExport.Text = "Export";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(481, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 106;
			this.label4.Text = "Rate";
			this.label4.Visible = false;
			// 
			// ddlEventName
			// 
			this.ddlEventName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ddlEventName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlEventName.FormattingEnabled = true;
			this.ddlEventName.Location = new System.Drawing.Point(911, 14);
			this.ddlEventName.Name = "ddlEventName";
			this.ddlEventName.Size = new System.Drawing.Size(144, 21);
			this.ddlEventName.TabIndex = 104;
			// 
			// ddlRate
			// 
			this.ddlRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlRate.FormattingEnabled = true;
			this.ddlRate.Location = new System.Drawing.Point(520, 16);
			this.ddlRate.Name = "ddlRate";
			this.ddlRate.Size = new System.Drawing.Size(108, 21);
			this.ddlRate.TabIndex = 103;
			this.ddlRate.Visible = false;
			// 
			// btnFindSeed
			// 
			this.btnFindSeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFindSeed.Location = new System.Drawing.Point(1061, 12);
			this.btnFindSeed.Name = "btnFindSeed";
			this.btnFindSeed.Size = new System.Drawing.Size(75, 23);
			this.btnFindSeed.TabIndex = 102;
			this.btnFindSeed.Text = "Find Seed";
			this.btnFindSeed.UseVisualStyleBackColor = true;
			this.btnFindSeed.Click += new System.EventHandler(this.btnFindSeed_Click);
			// 
			// tbSeed
			// 
			this.tbSeed.Location = new System.Drawing.Point(48, 43);
			this.tbSeed.Name = "tbSeed";
			this.tbSeed.Size = new System.Drawing.Size(109, 20);
			this.tbSeed.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Seed";
			// 
			// tbPullCount
			// 
			this.tbPullCount.Location = new System.Drawing.Point(49, 16);
			this.tbPullCount.Name = "tbPullCount";
			this.tbPullCount.Size = new System.Drawing.Size(108, 20);
			this.tbPullCount.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Count";
			// 
			// dgvPullList
			// 
			this.dgvPullList.AllowUserToAddRows = false;
			this.dgvPullList.AllowUserToDeleteRows = false;
			this.dgvPullList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvPullList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPullList.Location = new System.Drawing.Point(6, 72);
			this.dgvPullList.Name = "dgvPullList";
			this.dgvPullList.ReadOnly = true;
			this.dgvPullList.Size = new System.Drawing.Size(1130, 641);
			this.dgvPullList.TabIndex = 101;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1163, 762);
			this.tabControl1.TabIndex = 101;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1155, 736);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Tracks";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.tbOutput);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1155, 736);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Reference";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// ddlPullModifier
			// 
			this.ddlPullModifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlPullModifier.FormattingEnabled = true;
			this.ddlPullModifier.Items.AddRange(new object[] {
            "Normal",
            "Track B",
            "Guaranteed"});
			this.ddlPullModifier.Location = new System.Drawing.Point(172, 42);
			this.ddlPullModifier.Name = "ddlPullModifier";
			this.ddlPullModifier.Size = new System.Drawing.Size(121, 21);
			this.ddlPullModifier.TabIndex = 108;
			// 
			// frmBatCatTracks
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1167, 767);
			this.Controls.Add(this.tabControl1);
			this.Name = "frmBatCatTracks";
			this.Text = "Battle Cats Tracks Calculator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnExit);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPullList)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.Button btnGetPulls;
		private System.Windows.Forms.TextBox tbEventsToGet;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbPullCount;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgvPullList;
		private System.Windows.Forms.TextBox tbSeed;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnFindSeed;
		private System.Windows.Forms.ComboBox ddlRate;
		private System.Windows.Forms.ComboBox ddlEventName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.ComboBox ddlPullModifier;
	}
}

