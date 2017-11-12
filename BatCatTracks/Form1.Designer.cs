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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ddlGatchaSet = new System.Windows.Forms.ComboBox();
			this.ddlRate = new System.Windows.Forms.ComboBox();
			this.ddlPullModifier = new System.Windows.Forms.ComboBox();
			this.btnExport = new System.Windows.Forms.Button();
			this.ddlEventName = new System.Windows.Forms.ComboBox();
			this.btnFindSeed = new System.Windows.Forms.Button();
			this.tbSeed = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbPullCount = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dgvPullList = new System.Windows.Forms.DataGridView();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabTracks = new System.Windows.Forms.TabPage();
			this.tabReference = new System.Windows.Forms.TabPage();
			this.tabEquivUnits = new System.Windows.Forms.TabPage();
			this.dgvEquivalents = new System.Windows.Forms.DataGridView();
			this.dgcDynamites = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcNekoluga = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Vajiras = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcGalaxyGal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DragonEmps = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcUltraSouls = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcDarkHeroes = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcAlmighties = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcIronLegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcGirlsMons = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcElementals = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPullList)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabTracks.SuspendLayout();
			this.tabReference.SuspendLayout();
			this.tabEquivUnits.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvEquivalents)).BeginInit();
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
			this.btnGetPulls.Location = new System.Drawing.Point(290, 16);
			this.btnGetPulls.Name = "btnGetPulls";
			this.btnGetPulls.Size = new System.Drawing.Size(75, 23);
			this.btnGetPulls.TabIndex = 3;
			this.btnGetPulls.Text = "Calculate";
			this.btnGetPulls.UseVisualStyleBackColor = true;
			this.btnGetPulls.Click += new System.EventHandler(this.btnGetPulls_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.ddlGatchaSet);
			this.groupBox1.Controls.Add(this.ddlRate);
			this.groupBox1.Controls.Add(this.ddlPullModifier);
			this.groupBox1.Controls.Add(this.btnExport);
			this.groupBox1.Controls.Add(this.ddlEventName);
			this.groupBox1.Controls.Add(this.btnFindSeed);
			this.groupBox1.Controls.Add(this.tbSeed);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbPullCount);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.dgvPullList);
			this.groupBox1.Controls.Add(this.btnGetPulls);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1142, 719);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Get Pulls";
			// 
			// ddlGatchaSet
			// 
			this.ddlGatchaSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlGatchaSet.FormattingEnabled = true;
			this.ddlGatchaSet.Location = new System.Drawing.Point(163, 43);
			this.ddlGatchaSet.Name = "ddlGatchaSet";
			this.ddlGatchaSet.Size = new System.Drawing.Size(121, 21);
			this.ddlGatchaSet.TabIndex = 110;
			// 
			// ddlRate
			// 
			this.ddlRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlRate.FormattingEnabled = true;
			this.ddlRate.Location = new System.Drawing.Point(163, 15);
			this.ddlRate.Name = "ddlRate";
			this.ddlRate.Size = new System.Drawing.Size(121, 21);
			this.ddlRate.TabIndex = 109;
			// 
			// ddlPullModifier
			// 
			this.ddlPullModifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlPullModifier.FormattingEnabled = true;
			this.ddlPullModifier.Items.AddRange(new object[] {
            "Normal",
            "Track B",
            "Guaranteed"});
			this.ddlPullModifier.Location = new System.Drawing.Point(290, 44);
			this.ddlPullModifier.Name = "ddlPullModifier";
			this.ddlPullModifier.Size = new System.Drawing.Size(156, 21);
			this.ddlPullModifier.TabIndex = 108;
			// 
			// btnExport
			// 
			this.btnExport.Enabled = false;
			this.btnExport.Location = new System.Drawing.Point(371, 16);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(75, 23);
			this.btnExport.TabIndex = 107;
			this.btnExport.Text = "Export";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
			this.tabControl1.Controls.Add(this.tabTracks);
			this.tabControl1.Controls.Add(this.tabReference);
			this.tabControl1.Controls.Add(this.tabEquivUnits);
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1163, 762);
			this.tabControl1.TabIndex = 101;
			// 
			// tabTracks
			// 
			this.tabTracks.Controls.Add(this.groupBox1);
			this.tabTracks.Location = new System.Drawing.Point(4, 22);
			this.tabTracks.Name = "tabTracks";
			this.tabTracks.Padding = new System.Windows.Forms.Padding(3);
			this.tabTracks.Size = new System.Drawing.Size(1155, 736);
			this.tabTracks.TabIndex = 0;
			this.tabTracks.Text = "Tracks";
			this.tabTracks.UseVisualStyleBackColor = true;
			// 
			// tabReference
			// 
			this.tabReference.Controls.Add(this.tbOutput);
			this.tabReference.Location = new System.Drawing.Point(4, 22);
			this.tabReference.Name = "tabReference";
			this.tabReference.Padding = new System.Windows.Forms.Padding(3);
			this.tabReference.Size = new System.Drawing.Size(1155, 736);
			this.tabReference.TabIndex = 1;
			this.tabReference.Text = "Reference";
			this.tabReference.UseVisualStyleBackColor = true;
			// 
			// tabEquivUnits
			// 
			this.tabEquivUnits.Controls.Add(this.dgvEquivalents);
			this.tabEquivUnits.Location = new System.Drawing.Point(4, 22);
			this.tabEquivUnits.Name = "tabEquivUnits";
			this.tabEquivUnits.Size = new System.Drawing.Size(1155, 736);
			this.tabEquivUnits.TabIndex = 2;
			this.tabEquivUnits.Text = "Unit Equivalents";
			this.tabEquivUnits.UseVisualStyleBackColor = true;
			// 
			// dgvEquivalents
			// 
			this.dgvEquivalents.AllowUserToAddRows = false;
			this.dgvEquivalents.AllowUserToDeleteRows = false;
			this.dgvEquivalents.AllowUserToResizeRows = false;
			this.dgvEquivalents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEquivalents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDynamites,
            this.dgcNekoluga,
            this.Vajiras,
            this.dgcGalaxyGal,
            this.DragonEmps,
            this.dgcUltraSouls,
            this.dgcDarkHeroes,
            this.dgcAlmighties,
            this.dgcIronLegion,
            this.dgcGirlsMons,
            this.dgcElementals});
			this.dgvEquivalents.Location = new System.Drawing.Point(3, 3);
			this.dgvEquivalents.Name = "dgvEquivalents";
			this.dgvEquivalents.Size = new System.Drawing.Size(1145, 544);
			this.dgvEquivalents.TabIndex = 0;
			// 
			// dgcDynamites
			// 
			this.dgcDynamites.HeaderText = "Dynamites";
			this.dgcDynamites.Name = "dgcDynamites";
			// 
			// dgcNekoluga
			// 
			this.dgcNekoluga.HeaderText = "Nekoluga";
			this.dgcNekoluga.Name = "dgcNekoluga";
			this.dgcNekoluga.Width = 70;
			// 
			// Vajiras
			// 
			this.Vajiras.HeaderText = "Wargod Vajiras";
			this.Vajiras.Name = "Vajiras";
			this.Vajiras.Width = 110;
			// 
			// dgcGalaxyGal
			// 
			this.dgcGalaxyGal.HeaderText = "Galaxy Gals";
			this.dgcGalaxyGal.Name = "dgcGalaxyGal";
			this.dgcGalaxyGal.Width = 90;
			// 
			// DragonEmps
			// 
			this.DragonEmps.HeaderText = "Dragon Emps";
			this.DragonEmps.Name = "DragonEmps";
			this.DragonEmps.Width = 95;
			// 
			// dgcUltraSouls
			// 
			this.dgcUltraSouls.HeaderText = "Ultra Souls";
			this.dgcUltraSouls.Name = "dgcUltraSouls";
			// 
			// dgcDarkHeroes
			// 
			this.dgcDarkHeroes.HeaderText = "Dark Heroes";
			this.dgcDarkHeroes.Name = "dgcDarkHeroes";
			// 
			// dgcAlmighties
			// 
			this.dgcAlmighties.HeaderText = "Almighties";
			this.dgcAlmighties.Name = "dgcAlmighties";
			this.dgcAlmighties.Width = 105;
			// 
			// dgcIronLegion
			// 
			this.dgcIronLegion.HeaderText = "Iron Legion";
			this.dgcIronLegion.Name = "dgcIronLegion";
			// 
			// dgcGirlsMons
			// 
			this.dgcGirlsMons.HeaderText = "Girls Mons";
			this.dgcGirlsMons.Name = "dgcGirlsMons";
			// 
			// dgcElementals
			// 
			this.dgcElementals.HeaderText = "Elementals";
			this.dgcElementals.Name = "dgcElementals";
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
			this.tabTracks.ResumeLayout(false);
			this.tabReference.ResumeLayout(false);
			this.tabReference.PerformLayout();
			this.tabEquivUnits.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvEquivalents)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.Button btnGetPulls;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbPullCount;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgvPullList;
		private System.Windows.Forms.TextBox tbSeed;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnFindSeed;
		private System.Windows.Forms.ComboBox ddlEventName;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabTracks;
		private System.Windows.Forms.TabPage tabReference;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.ComboBox ddlPullModifier;
		private System.Windows.Forms.TabPage tabEquivUnits;
		private System.Windows.Forms.DataGridView dgvEquivalents;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcDynamites;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcNekoluga;
		private System.Windows.Forms.DataGridViewTextBoxColumn Vajiras;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcGalaxyGal;
		private System.Windows.Forms.DataGridViewTextBoxColumn DragonEmps;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcUltraSouls;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcDarkHeroes;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcAlmighties;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcIronLegion;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcGirlsMons;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcElementals;
		private System.Windows.Forms.ComboBox ddlRate;
		private System.Windows.Forms.ComboBox ddlGatchaSet;
	}
}

