using BatCatTracks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatCatTracks
{
	public partial class frmSeedCalculator : Form
	{
		private TrackChecker checker;
		private List<Unit> currentUnits;
		private Timer progressTimer = new Timer();
		private const long seedRange = (long)int.MaxValue - int.MinValue;

		public Action<int> SeedUpdater = null;

		public frmSeedCalculator(TrackChecker _checker)
		{
			InitializeComponent();

			checker = _checker;
			progressTimer.Tick += TimerTick;
			progressTimer.Interval = 500;
			progressTimer.Enabled = false;

			calculationProgress.Value = calculationProgress.Minimum = 0;
			calculationProgress.Maximum = 1000;
		}

		public void SetAvailableUnits(List<Unit> availableUnits)
		{
			currentUnits = availableUnits;
			SetupDropDown();
		}

		private void SetupDropDown()
		{
			var sortedUnits = new List<Unit>(currentUnits);
			sortedUnits.Sort((a, b) =>
			{

				if (a.Rarity.CompareTo(b.Rarity) != 0)
					return a.Rarity.CompareTo(b.Rarity);
				else
					return a.Name.CompareTo(b.Name);
			});

			ddlUnitList.DataSource = sortedUnits;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Unit unit = (Unit)ddlUnitList.SelectedItem;

			dgvCatList.Rows.Add(unit.Id, unit.Rarity, unit.Name);
		}

		private async void btnFindSeed_Click(object sender, EventArgs e)
		{
			if (dgvCatList.Rows.Count < 10)
			{
				MessageBox.Show("Please enter at least 10 pulls.");
				return;
			}
			string knownPulls = string.Empty;

			foreach (var row in dgvCatList.Rows)
			{
				if (knownPulls != string.Empty)
					knownPulls += ",";

				var val = ((DataGridViewRow)row).Cells[0].Value;

				knownPulls += val;
			}

			var knownUnits = checker.ConvertIdsToUnits(knownPulls);

			DisableControls();
			progressTimer.Enabled = true;

			System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
			stopwatch.Start();

			int seed = await checker.FindSeedAsync(knownUnits, currentUnits, GatchaSets.Instance.RarityRates["Five"]);

			stopwatch.Stop();

			progressTimer.Enabled = false;
			lblProgress.Text = "Done";
			calculationProgress.Value = 0;
			lblPercent.Text = "0.0%";

			EnableControls();

			// method returns 0 if task was aborted, as 0 is not a valid seed
			if (seed != 0)
			{
				tbSeed.Text = seed.ToString();
				SeedUpdater?.Invoke(seed);
				MessageBox.Show(string.Format("Seed found in {0} seconds.", stopwatch.Elapsed.TotalSeconds));
			}
		}

		private void DisableControls()
		{
			btnAdd.Enabled = false;
			btnFindSeed.Enabled = false;
			ddlUnitList.Enabled = false;
			dgvCatList.Enabled = false;
		}

		private void EnableControls()
		{
			btnAdd.Enabled = true;
			btnFindSeed.Enabled = true;
			ddlUnitList.Enabled = true;
			dgvCatList.Enabled = true;
		}

		private void TimerTick(object sender, EventArgs e)
		{
			lblProgress.Text = checker.currentSeed.ToString();

			long curSeed = (long)checker.currentSeed - int.MinValue;
			int curProgress = (int)(((decimal)curSeed / (decimal)seedRange) * 1000);
			lblPercent.Text = ((decimal)curProgress / 10).ToString("0.0") + "%";
			
			calculationProgress.Value = curProgress;
		}

		private void frmSeedCalculator_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				checker.AbortCalculation = true;
				e.Cancel = true;
				Hide();
			}
		}
	}
}
