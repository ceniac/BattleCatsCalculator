using BatCatTracks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatCatTracks
{
	public partial class frmBatCatTracks : Form
	{
		private TrackChecker checker = new TrackChecker();
		private frmSeedCalculator seedCalc;

		public frmBatCatTracks()
		{
			InitializeComponent();

			LoadSettings();

			PopulateStuff();

			foreach (string name in checker.RarityRates.Keys)
			{
				ddlRate.Items.Add(name);
			}
			ddlRate.SelectedIndex = 1;

			foreach (var evt in checker.Events)
			{
				ddlEventName.Items.Add(evt.Name);
			}
			ddlEventName.SelectedIndex = 0;

			seedCalc = new frmSeedCalculator(checker);
			seedCalc.SeedUpdater = i => tbSeed.Text = i.ToString();
		}

		private void LoadSettings()
		{
			if (ConfigurationManager.AppSettings["Seed"] != null)
				tbSeed.Text = ConfigurationManager.AppSettings["Seed"];
			else
				tbSeed.Text = "0";

			if (ConfigurationManager.AppSettings["PullCount"] != null)
				tbPullCount.Text = ConfigurationManager.AppSettings["PullCount"];
			else
				tbPullCount.Text = "100";
		}

		private void PopulateStuff()
		{
			foreach (var evt in checker.EventUnits.Keys)
			{
				var list = checker.EventUnits[evt];

				string ubers = string.Empty;
				string supers = string.Empty;

				foreach (var u in list)
				{
					if (u.Rarity == Models.Rarity.UberRare)
						ubers += (ubers == string.Empty ? string.Empty : ", ") + u.Name;
					else
						supers += (supers == string.Empty ? string.Empty : ", ") + u.Name;
				}

				if (ubers != string.Empty)
				{
					string line = evt + ": " + ubers + Environment.NewLine;
					if (supers != string.Empty)
						line += supers + Environment.NewLine;
					tbOutput.Text += line + Environment.NewLine;
				}
			}

			// 160 = normal
			// 154 = ultrasouls
			// 173 = ultrafest
			// 168 = uberfest
			// 167 = air
			// 166 = red
		}

		private void btnGetPulls_Click(object sender, EventArgs e)
		{
			var pullCount = 0;
			if (!int.TryParse(tbPullCount.Text, out pullCount))
			{
				MessageBox.Show("Please enter a valid count.");
				return;
			}
			var seed = 0;
			if (!int.TryParse(tbSeed.Text, out seed))
			{
				MessageBox.Show("Please enter a valid seed.");
				return;
			}
			//var gatcha = checker.EventUnits[Convert.ToInt32(tbEventsToGet.Text)];
			//var rarity = checker.RarityRates[(string)ddlRate.SelectedItem];

			var gatcha = SelectedEvent;

			//var result = checker.GetUnits(seed, pullCount, gatcha, rarity);
			var result = checker.GetUnits(seed, pullCount, gatcha.Units, gatcha.RarityRate, cbTrackB.Checked);

			dgvPullList.DataSource = result;
		}

		private void btnFindSeed_Click(object sender, EventArgs e)
		{
			seedCalc.SetAvailableUnits(SelectedEvent.Units);

			seedCalc.Show();
		}

		private GatchaEvent SelectedEvent
		{
			get { return checker.Events.FirstOrDefault(g => g.Name == (string)ddlEventName.SelectedItem); }
		}

		private void OnExit(object sender, FormClosingEventArgs e)
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			var pullCount = 0;
			if (int.TryParse(tbPullCount.Text, out pullCount))
				config.AppSettings.Settings["PullCount"].Value = pullCount.ToString();

			var seed = 0;
			if (int.TryParse(tbSeed.Text, out seed))
				config.AppSettings.Settings["Seed"].Value = seed.ToString();

			config.Save(ConfigurationSaveMode.Modified);
		}
	}
}
