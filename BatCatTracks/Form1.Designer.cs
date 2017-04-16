﻿namespace BatCatTracks
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
			this.label4 = new System.Windows.Forms.Label();
			this.cbTrackB = new System.Windows.Forms.CheckBox();
			this.ddlEventName = new System.Windows.Forms.ComboBox();
			this.ddlRate = new System.Windows.Forms.ComboBox();
			this.btnFindSeed = new System.Windows.Forms.Button();
			this.tbSeed = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbPullCount = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dgvPullList = new System.Windows.Forms.DataGridView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPullList)).BeginInit();
			this.SuspendLayout();
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(12, 12);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(690, 143);
			this.tbOutput.TabIndex = 100;
			// 
			// btnGetPulls
			// 
			this.btnGetPulls.Location = new System.Drawing.Point(80, 96);
			this.btnGetPulls.Name = "btnGetPulls";
			this.btnGetPulls.Size = new System.Drawing.Size(75, 23);
			this.btnGetPulls.TabIndex = 3;
			this.btnGetPulls.Text = "Calculate";
			this.btnGetPulls.UseVisualStyleBackColor = true;
			this.btnGetPulls.Click += new System.EventHandler(this.btnGetPulls_Click);
			// 
			// tbEventsToGet
			// 
			this.tbEventsToGet.Location = new System.Drawing.Point(47, 298);
			this.tbEventsToGet.Name = "tbEventsToGet";
			this.tbEventsToGet.Size = new System.Drawing.Size(108, 20);
			this.tbEventsToGet.TabIndex = 0;
			this.tbEventsToGet.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 301);
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
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.cbTrackB);
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
			this.groupBox1.Location = new System.Drawing.Point(13, 161);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(689, 397);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Get Pulls";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 274);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 106;
			this.label4.Text = "Rate";
			this.label4.Visible = false;
			// 
			// cbTrackB
			// 
			this.cbTrackB.AutoSize = true;
			this.cbTrackB.Location = new System.Drawing.Point(11, 102);
			this.cbTrackB.Name = "cbTrackB";
			this.cbTrackB.Size = new System.Drawing.Size(64, 17);
			this.cbTrackB.TabIndex = 105;
			this.cbTrackB.Text = "Track B";
			this.cbTrackB.UseVisualStyleBackColor = true;
			// 
			// ddlEventName
			// 
			this.ddlEventName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlEventName.FormattingEnabled = true;
			this.ddlEventName.Location = new System.Drawing.Point(11, 16);
			this.ddlEventName.Name = "ddlEventName";
			this.ddlEventName.Size = new System.Drawing.Size(144, 21);
			this.ddlEventName.TabIndex = 104;
			// 
			// ddlRate
			// 
			this.ddlRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlRate.FormattingEnabled = true;
			this.ddlRate.Location = new System.Drawing.Point(46, 271);
			this.ddlRate.Name = "ddlRate";
			this.ddlRate.Size = new System.Drawing.Size(108, 21);
			this.ddlRate.TabIndex = 103;
			this.ddlRate.Visible = false;
			// 
			// btnFindSeed
			// 
			this.btnFindSeed.Location = new System.Drawing.Point(80, 125);
			this.btnFindSeed.Name = "btnFindSeed";
			this.btnFindSeed.Size = new System.Drawing.Size(75, 23);
			this.btnFindSeed.TabIndex = 102;
			this.btnFindSeed.Text = "Find Seed";
			this.btnFindSeed.UseVisualStyleBackColor = true;
			this.btnFindSeed.Click += new System.EventHandler(this.btnFindSeed_Click);
			// 
			// tbSeed
			// 
			this.tbSeed.Location = new System.Drawing.Point(46, 70);
			this.tbSeed.Name = "tbSeed";
			this.tbSeed.Size = new System.Drawing.Size(109, 20);
			this.tbSeed.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Seed";
			// 
			// tbPullCount
			// 
			this.tbPullCount.Location = new System.Drawing.Point(47, 43);
			this.tbPullCount.Name = "tbPullCount";
			this.tbPullCount.Size = new System.Drawing.Size(108, 20);
			this.tbPullCount.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 46);
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
			this.dgvPullList.Location = new System.Drawing.Point(161, 16);
			this.dgvPullList.Name = "dgvPullList";
			this.dgvPullList.ReadOnly = true;
			this.dgvPullList.Size = new System.Drawing.Size(522, 375);
			this.dgvPullList.TabIndex = 101;
			// 
			// frmBatCatTracks
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(715, 570);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tbOutput);
			this.Name = "frmBatCatTracks";
			this.Text = "Battle Cats Tracks Calculator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnExit);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPullList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

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
		private System.Windows.Forms.CheckBox cbTrackB;
		private System.Windows.Forms.Label label4;
	}
}

