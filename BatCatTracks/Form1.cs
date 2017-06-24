using BatCatTracks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatCatTracks
{
	public partial class frmBatCatTracks : Form
	{
		private TrackChecker checker = new TrackChecker();
		private frmSeedCalculator seedCalc;
		private List<string> export = null;

		public frmBatCatTracks()
		{
			InitializeComponent();

			DoubleBufferDGV();

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

		private void DoubleBufferDGV()
		{
			typeof(DataGridView).InvokeMember(
			   "DoubleBuffered",
			   BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
			   null,
			   dgvPullList,
			   new object[] { true });
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

			ddlPullModifier.SelectedIndex = 0;
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

			export = new List<string>();

			string exportRow = "Row,Seed,NormalUnit,Rarity,UltraSouls,Rarity,RedBusters,Rarity,AirBusters,Rarity,UberFest,Rarity,UltraFest,Rarity";
			export.Add(exportRow);
			var gatcha = checker.Events.First(g => g.Id == Constants.Almighties);
			var almighties = checker.GetUnits(seed, pullCount, gatcha.Units, gatcha.RarityRate, CurrentPullMode);
			gatcha = checker.Events.First(g => g.Id == Constants.UltraSouls);
			var ultrasouls = checker.GetUnits(seed, pullCount, gatcha.Units, gatcha.RarityRate, CurrentPullMode);
			gatcha = checker.Events.First(g => g.Id == Constants.RedBusters);
			var redbusters = checker.GetUnits(seed, pullCount, gatcha.Units, gatcha.RarityRate, CurrentPullMode);
			gatcha = checker.Events.First(g => g.Id == Constants.AirBusters);
			var airbusters = checker.GetUnits(seed, pullCount, gatcha.Units, gatcha.RarityRate, CurrentPullMode);
			gatcha = checker.Events.First(g => g.Id == Constants.UberFest);
			var uberfest = checker.GetUnits(seed, pullCount, gatcha.Units, gatcha.RarityRate, CurrentPullMode);
			gatcha = checker.Events.First(g => g.Id == Constants.EpicFest);
			var epicfest = checker.GetUnits(seed, pullCount, gatcha.Units, gatcha.RarityRate, CurrentPullMode);

			var table = new List<GatchaRow>();

			for (int i = 0; i < pullCount; i++)
			{
				var row = new GatchaRow();
				row.Count = i;
				row.Seed = almighties[i].Seed;
				row.NormUnit = almighties[i].Name;
				row.NR = RarityToPips(almighties[i].Rarity);
				if (almighties[i].Name != ultrasouls[i].Name)
				{
					row.USUnit = ultrasouls[i].Name;
					row.USR = RarityToPips(ultrasouls[i].Rarity);
				}
				if (almighties[i].Name != redbusters[i].Name)
				{
					row.RBUnit = redbusters[i].Name;
					row.RBR = RarityToPips(redbusters[i].Rarity);
				}
				if (almighties[i].Name != airbusters[i].Name)
				{
					row.ABUnit = airbusters[i].Name;
					row.ABR = RarityToPips(airbusters[i].Rarity);
				}
				if (almighties[i].Name != uberfest[i].Name)
				{
					row.UFUnit = uberfest[i].Name;
					row.UFR = RarityToPips(uberfest[i].Rarity);
				}
				if (almighties[i].Name != epicfest[i].Name)
				{
					row.EFUnit = epicfest[i].Name;
					row.EFR = RarityToPips(epicfest[i].Rarity);
				}

				table.Add(row);

				exportRow = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
					i, row.Seed, row.NormUnit, row.NR, row.USUnit, row.USR, row.RBUnit, row.RBR, row.ABUnit, row.ABR, row.UFUnit, row.UFR, row.EFUnit, row.EFR);
				export.Add(exportRow);
			}
			btnExport.Enabled = true;

			dgvPullList.DataSource = table;
			dgvPullList.AutoResizeColumns();
		}

		private class GatchaRow
		{
			public int Count { get; set; }
			public int Seed { get; set; }
			public string NormUnit { get; set; }
			public string NR { get; set; }
			public string USUnit { get; set; }
			public string USR { get; set; }
			public string RBUnit { get; set; }
			public string RBR { get; set; }
			public string ABUnit { get; set; }
			public string ABR { get; set; }
			public string UFUnit { get; set; }
			public string UFR { get; set; }
			public string EFUnit { get; set; }
			public string EFR { get; set; }
		}

		private string RarityToPips(Rarity r)
		{
			if (r == Rarity.UberRare)
				return "U";
			else if (r == Rarity.SuperRare)
				return "s";
			else
				return "";
		}

		private void btnFindSeed_Click(object sender, EventArgs e)
		{
			seedCalc.SetAvailableUnits(SelectedEvent.Units);

			seedCalc.Show();
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			using (SaveFileDialog dialog = new SaveFileDialog())
			{
				dialog.Filter = "Comma separated files (*.csv)|*.csv|All files (*.*)|*.*";
				dialog.FilterIndex = 1;
				dialog.RestoreDirectory = true;

				if (dialog.ShowDialog() == DialogResult.OK)
				{
					using (StreamWriter stream = new StreamWriter(dialog.OpenFile()))
					{
						export.ForEach(line => stream.WriteLine(line));
					}
				}
			}
		}

		private GatchaEvent SelectedEvent
		{
			get { return checker.Events.FirstOrDefault(g => g.Name == (string)ddlEventName.SelectedItem); }
		}

		private PullMode CurrentPullMode
		{
			get { return (PullMode)ddlPullModifier.SelectedIndex; }
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
