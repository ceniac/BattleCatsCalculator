using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BatCatTracks.Models
{
	public class GatchaSets
	{
		public static readonly GatchaSets Instance;

		//private List<Unit> RareUnits;

		public List<Unit> AllUnits;
		public Dictionary<int, List<Unit>> EventUnits;

		private readonly List<RarityRange> NinePercent = new List<RarityRange>();
		private readonly List<RarityRange> FivePercent = new List<RarityRange>();
		private readonly List<RarityRange> FourPercent = new List<RarityRange>();
		private readonly List<RarityRange> ThreePercent = new List<RarityRange>();
		public readonly Dictionary<string, List<RarityRange>> RarityRates = new Dictionary<string, List<RarityRange>>();

		public readonly List<GatchaEvent> Events = new List<GatchaEvent>();

		static GatchaSets()
		{
			Instance = new GatchaSets();

			Instance.LoadUnitData();
			Instance.LoadEventData();
			Instance.LoadRarityRanges();
			Instance.SetupCommonEvents();
			//Instance.LoadRares();
		}

		private void LoadRarityRanges()
		{
			var range = new RarityRange { Rarity = Rarity.Rare, Min = 0, Max = 6499 };
			NinePercent.Add(range);
			range = new RarityRange { Rarity = Rarity.SuperRare, Min = 6500, Max = 9099 };
			NinePercent.Add(range);
			range = new RarityRange { Rarity = Rarity.UberRare, Min = 9100, Max = 9999 };
			NinePercent.Add(range);

			range = new RarityRange { Rarity = Rarity.Rare, Min = 0, Max = 7499 };
			FivePercent.Add(range);
			range = new RarityRange { Rarity = Rarity.SuperRare, Min = 7500, Max = 9499 };
			FivePercent.Add(range);
			range = new RarityRange { Rarity = Rarity.UberRare, Min = 9500, Max = 9999 };
			FivePercent.Add(range);

			range = new RarityRange { Rarity = Rarity.Rare, Min = 0, Max = 7499 };
			FourPercent.Add(range);
			range = new RarityRange { Rarity = Rarity.SuperRare, Min = 7500, Max = 9599 };
			FourPercent.Add(range);
			range = new RarityRange { Rarity = Rarity.UberRare, Min = 9600, Max = 9999 };
			FourPercent.Add(range);
			
			range = new RarityRange { Rarity = Rarity.Rare, Min = 0, Max = 7499 };
			ThreePercent.Add(range);
			range = new RarityRange { Rarity = Rarity.SuperRare, Min = 7500, Max = 9699 };
			ThreePercent.Add(range);
			range = new RarityRange { Rarity = Rarity.UberRare, Min = 9700, Max = 9999 };
			ThreePercent.Add(range);

			RarityRates.Add("Three", ThreePercent);
			RarityRates.Add("Four", FourPercent);
			RarityRates.Add("Five", FivePercent);
			RarityRates.Add("Nine", NinePercent);
		}

		private void LoadUnitData()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "BatCatTracks.Data.units.csv";

			List<string> lines;

			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			using (StreamReader reader = new StreamReader(stream))
			{
				lines = new List<string>(reader.ReadToEnd().Split('\n'));
			}

			AllUnits = new List<Unit>();
			foreach (string line in lines)
			{
				var fields = line.Split('|');
				if (fields != null && fields.Length >= 3)
				{
					var unit = new Unit { Id = int.Parse(fields[0]), Name = fields[2] };
					Rarity rarity;
					Enum.TryParse<Rarity>(fields[1], out rarity);
					unit.Rarity = rarity;

					AllUnits.Add(unit);
				}
			}
		}

		private void LoadEventData()
		{
			string curline = null;
			try
			{
				var assembly = Assembly.GetExecutingAssembly();
				var resourceName = "BatCatTracks.Data.GatyaDataSetR1.csv";

				List<string> lines;

				using (Stream stream = assembly.GetManifestResourceStream(resourceName))
				using (StreamReader reader = new StreamReader(stream))
				{
					lines = new List<string>(reader.ReadToEnd().Split('\n'));
				}

				EventUnits = new Dictionary<int, List<Unit>>();

				int lineNum = 0;
				foreach (string line in lines)
				{
					curline = line;
					if (string.IsNullOrWhiteSpace(line))
						continue;
					var fields = line.Split(',');
					List<Unit> curEvent = new List<Unit>();
					bool validEvent = true;

					foreach (string s in fields)
					{
						if (s == "-1")
							break;

						var unit = AllUnits.SingleOrDefault(u => u.Id == Convert.ToInt32(s));
						// Skip events that have non-US cats
						if (unit == null)
						{
							validEvent = false;
							break;
						}
						curEvent.Add(unit);
					}

					if (validEvent)
						EventUnits[lineNum] = curEvent;

					lineNum++;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Error loading event " + curline);
			}
		}

		private void SetupCommonEvents()
		{
			GatchaEvent evt = new GatchaEvent
			{
				Id = Constants.Nekoluga,
				Name = "Nekoluga",
				RarityRate = FivePercent,
				IsRegular = true
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.Dynamites,
				Name = "Dynamites",
				RarityRate = FivePercent,
				IsRegular = true
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.GalaxyGals,
				Name = "GalaxyGals",
				RarityRate = FivePercent,
				IsRegular = true
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.DragonEmps,
				Name = "Dragon Emporors",
				RarityRate = FivePercent,
				IsRegular = true
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.DarkHeroes,
				Name = "Dark Heroes",
				RarityRate = FivePercent,
				IsRegular = true
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.Almighties,
				Name = "Almighties",
				RarityRate = FivePercent,
				IsRegular = true
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.IronLegion,
				Name = "Iron Legion",
				RarityRate = FivePercent,
				IsRegular = true
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.GirlsMons,
				Name = "Girls Monsters",
				RarityRate = FivePercent,
				IsRegular = true
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.Elementals,
				Name = "Elementals",
				RarityRate = FivePercent,
				IsRegular = true
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.UltraSouls,
				Name = "Ultra Souls",
				RarityRate = FivePercent,
				IsRegular = true
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.Vajiras,
				Name = "Vajiras",
				RarityRate = FivePercent,
				IsRegular = true
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.RedBusters,
				Name = "Red Busters",
				RarityRate = FivePercent,
				IsRegular = false
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.AirBusters,
				Name = "Air Busters",
				RarityRate = FivePercent,
				IsRegular = false
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.MetalBusters,
				Name = "Metal Busters",
				RarityRate = FivePercent,
				IsRegular = false
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.UberFest,
				Name = "Uberfest",
				RarityRate = NinePercent,
				IsRegular = false
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = Constants.EpicFest,
				Name = "Epicfest",
				RarityRate = NinePercent,
				IsRegular = false
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			// limited
			
			//evt = new GatchaEvent
			//{
			//	Id = Constants.Baseball,
			//	Name = "Baseball",
			//	RarityRate = FivePercent,
			//	IsRegular = true
			//};
			//evt.Units = EventUnits[evt.Id];
			//Events.Add(evt);
		}

		//private void LoadRares()
		//{
		//	string rares = "198,197,149,148,147,146,145,58,56,55,52,51,50,49,48,47,46,41,38,37,308,325";

		//	RareUnits = ConvertIdsToUnits(rares);
		//}
	}
}
