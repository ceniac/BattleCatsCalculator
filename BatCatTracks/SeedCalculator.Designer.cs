namespace BatCatTracks
{
	partial class frmSeedCalculator
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
			this.btnFindSeed = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.ddlUnitList = new System.Windows.Forms.ComboBox();
			this.dgvCatList = new System.Windows.Forms.DataGridView();
			this.dgcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcRarity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tbSeed = new System.Windows.Forms.TextBox();
			this.calculationProgress = new System.Windows.Forms.ProgressBar();
			this.lblProgress = new System.Windows.Forms.Label();
			this.lblPercent = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvCatList)).BeginInit();
			this.SuspendLayout();
			// 
			// btnFindSeed
			// 
			this.btnFindSeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFindSeed.Location = new System.Drawing.Point(353, 440);
			this.btnFindSeed.Name = "btnFindSeed";
			this.btnFindSeed.Size = new System.Drawing.Size(75, 23);
			this.btnFindSeed.TabIndex = 0;
			this.btnFindSeed.Text = "Find Seed";
			this.btnFindSeed.UseVisualStyleBackColor = true;
			this.btnFindSeed.Click += new System.EventHandler(this.btnFindSeed_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(353, 12);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// ddlUnitList
			// 
			this.ddlUnitList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ddlUnitList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlUnitList.FormattingEnabled = true;
			this.ddlUnitList.Location = new System.Drawing.Point(13, 13);
			this.ddlUnitList.Name = "ddlUnitList";
			this.ddlUnitList.Size = new System.Drawing.Size(334, 21);
			this.ddlUnitList.TabIndex = 2;
			// 
			// dgvCatList
			// 
			this.dgvCatList.AllowUserToAddRows = false;
			this.dgvCatList.AllowUserToResizeRows = false;
			this.dgvCatList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvCatList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCatList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcId,
            this.dgcRarity,
            this.dgcName});
			this.dgvCatList.Location = new System.Drawing.Point(13, 41);
			this.dgvCatList.Name = "dgvCatList";
			this.dgvCatList.ReadOnly = true;
			this.dgvCatList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCatList.Size = new System.Drawing.Size(415, 364);
			this.dgvCatList.TabIndex = 3;
			// 
			// dgcId
			// 
			this.dgcId.HeaderText = "Id";
			this.dgcId.Name = "dgcId";
			this.dgcId.ReadOnly = true;
			// 
			// dgcRarity
			// 
			this.dgcRarity.HeaderText = "Rarity";
			this.dgcRarity.Name = "dgcRarity";
			this.dgcRarity.ReadOnly = true;
			// 
			// dgcName
			// 
			this.dgcName.HeaderText = "Name";
			this.dgcName.Name = "dgcName";
			this.dgcName.ReadOnly = true;
			// 
			// tbSeed
			// 
			this.tbSeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSeed.Location = new System.Drawing.Point(247, 443);
			this.tbSeed.Name = "tbSeed";
			this.tbSeed.ReadOnly = true;
			this.tbSeed.Size = new System.Drawing.Size(100, 20);
			this.tbSeed.TabIndex = 4;
			// 
			// calculationProgress
			// 
			this.calculationProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.calculationProgress.Location = new System.Drawing.Point(13, 412);
			this.calculationProgress.Name = "calculationProgress";
			this.calculationProgress.Size = new System.Drawing.Size(415, 23);
			this.calculationProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.calculationProgress.TabIndex = 5;
			// 
			// lblProgress
			// 
			this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblProgress.AutoSize = true;
			this.lblProgress.Location = new System.Drawing.Point(12, 445);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(38, 13);
			this.lblProgress.TabIndex = 6;
			this.lblProgress.Text = "Ready";
			// 
			// lblPercent
			// 
			this.lblPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPercent.AutoSize = true;
			this.lblPercent.Location = new System.Drawing.Point(187, 446);
			this.lblPercent.Name = "lblPercent";
			this.lblPercent.Size = new System.Drawing.Size(30, 13);
			this.lblPercent.TabIndex = 7;
			this.lblPercent.Text = "0.0%";
			this.lblPercent.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// frmSeedCalculator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 475);
			this.Controls.Add(this.lblPercent);
			this.Controls.Add(this.lblProgress);
			this.Controls.Add(this.calculationProgress);
			this.Controls.Add(this.tbSeed);
			this.Controls.Add(this.dgvCatList);
			this.Controls.Add(this.ddlUnitList);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnFindSeed);
			this.Name = "frmSeedCalculator";
			this.Text = "Seed Calculator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSeedCalculator_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dgvCatList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnFindSeed;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ComboBox ddlUnitList;
		private System.Windows.Forms.DataGridView dgvCatList;
		private System.Windows.Forms.TextBox tbSeed;
		private System.Windows.Forms.ProgressBar calculationProgress;
		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.Label lblPercent;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcId;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcRarity;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcName;
	}
}