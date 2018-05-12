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

			foreach (string name in GatchaSets.Instance.RarityRates.Keys)
			{
				ddlRate.Items.Add(name);
			}
			ddlRate.SelectedIndex = 2;

			foreach (GatchaEvent evt in GatchaSets.Instance.Events.Where(e => e.IsRegular).OrderBy(e => e.Name))
			{
				ddlGatchaSet.Items.Add(evt.Name);
			}
			ddlGatchaSet.SelectedIndex = 0;

			foreach (var evt in GatchaSets.Instance.Events)
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
			foreach (var evt in GatchaSets.Instance.EventUnits.Keys)
			{
				var list = GatchaSets.Instance.EventUnits[evt];

				string ubers = string.Empty;
				string supers = string.Empty;

				foreach (var u in list)
				{
					if (u.Rarity == Rarity.UberRare)
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

			var equiv = new List<List<string>>();

			AddUnits(equiv, Constants.Dynamites);
			AddUnits(equiv, Constants.Nekoluga);
			AddUnits(equiv, Constants.Vajiras);
			AddUnits(equiv, Constants.GalaxyGals);
			AddUnits(equiv, Constants.DragonEmps);
			AddUnits(equiv, Constants.UltraSouls);
			AddUnits(equiv, Constants.DarkHeroes);
			AddUnits(equiv, Constants.Almighties);
			AddUnits(equiv, Constants.IronLegion);
			AddUnits(equiv, Constants.GirlsMons);
			AddUnits(equiv, Constants.Elementals);

			// limited:
			//AddUnits(equiv, Constants.Baseball);
			//AddUnits(equiv, Constants.Eva);

			for (int i = 0; i < 7; i++)
			{
				List<string> row = new List<string>();
				equiv.ForEach(e => row.Add(e[i]));
				dgvEquivalents.Rows.Add(row.ToArray());
			}

			dgvEquivalents.AutoResizeColumns();

#if !DEBUG
			tabControl1.TabPages.Remove(tabReference);
#endif
		}

		private void AddUnits(List<List<string>> equiv, int eventId)
		{
			List<string> units = new List<string>();
			GatchaSets.Instance.EventUnits[eventId].ForEach(u => { if (u.Rarity == Rarity.UberRare) units.Add(u.Name); });
			units.Reverse();

			if (units.Count == 3)
			{
				units.Add(units[0]);
				units.Add(units[1]);
				units.Add(units[2]);
			}

			if (units.Count < 7)
			{
				int toAdd = 7 - units.Count;
				for (int i = 0; i < toAdd; i++)
				{
					units.Add(null);
				}
			}

			equiv.Add(units);
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

			var curRate = GatchaSets.Instance.RarityRates[ddlRate.SelectedItem.ToString()];

			string exportRow = "Row,Seed,NormalUnit,Rarity,RedBusters,Rarity,AirBusters,Rarity,MetalBusters,Rarity,UberFest,Rarity,UltraFest,Rarity";
			export.Add(exportRow);
			var gatcha = GatchaSets.Instance.Events.First(u => u.Name == ddlGatchaSet.SelectedItem.ToString());
			var selectedSet = checker.GetUnits(seed, pullCount, gatcha.Units, curRate, CurrentPullMode);
			gatcha = GatchaSets.Instance.Events.First(g => g.Id == Constants.RedBusters);
			var redbusters = checker.GetUnits(seed, pullCount, gatcha.Units, gatcha.RarityRate, CurrentPullMode);
			gatcha = GatchaSets.Instance.Events.First(g => g.Id == Constants.AirBusters);
			var airbusters = checker.GetUnits(seed, pullCount, gatcha.Units, gatcha.RarityRate, CurrentPullMode);
			gatcha = GatchaSets.Instance.Events.First(g => g.Id == Constants.MetalBusters);
			var metalbusters = checker.GetUnits(seed, pullCount, gatcha.Units, gatcha.RarityRate, CurrentPullMode);
			gatcha = GatchaSets.Instance.Events.First(g => g.Id == Constants.UberFest);
			var uberfest = checker.GetUnits(seed, pullCount, gatcha.Units, gatcha.RarityRate, CurrentPullMode);
			gatcha = GatchaSets.Instance.Events.First(g => g.Id == Constants.EpicFest);
			var epicfest = checker.GetUnits(seed, pullCount, gatcha.Units, gatcha.RarityRate, CurrentPullMode);

			var table = new List<GatchaRow>();

			for (int i = 0; i < pullCount; i++)
			{
				var row = new GatchaRow();
				row.Count = i;
				row.Seed = selectedSet[i].Seed;
				row.NormUnit = selectedSet[i].Name;
				row.NR = RarityToPips(selectedSet[i].Rarity);
				if (selectedSet[i].Name != redbusters[i].Name)
				{
					row.RBUnit = redbusters[i].Name;
					row.RBR = RarityToPips(redbusters[i].Rarity);
				}
				if (selectedSet[i].Name != airbusters[i].Name)
				{
					row.ABUnit = airbusters[i].Name;
					row.ABR = RarityToPips(airbusters[i].Rarity);
				}
				if (selectedSet[i].Name != metalbusters[i].Name)
				{
					row.MBUnit = metalbusters[i].Name;
					row.MBR = RarityToPips(metalbusters[i].Rarity);
				}
				if (selectedSet[i].Name != uberfest[i].Name)
				{
					row.UFUnit = uberfest[i].Name;
					row.UFR = RarityToPips(uberfest[i].Rarity);
				}
				if (selectedSet[i].Name != epicfest[i].Name)
				{
					row.EFUnit = epicfest[i].Name;
					row.EFR = RarityToPips(epicfest[i].Rarity);
				}

				table.Add(row);

				exportRow = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
					i, row.Seed, row.NormUnit, row.NR, row.RBUnit, row.RBR, row.ABUnit, row.ABR, row.MBUnit, row.MBR, row.UFUnit, row.UFR, row.EFUnit, row.EFR);
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
			public string RBUnit { get; set; }
			public string RBR { get; set; }
			public string ABUnit { get; set; }
			public string ABR { get; set; }
			public string MBUnit { get; set; }
			public string MBR { get; set; }
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
			get { return GatchaSets.Instance.Events.FirstOrDefault(g => g.Name == (string)ddlEventName.SelectedItem); }
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
