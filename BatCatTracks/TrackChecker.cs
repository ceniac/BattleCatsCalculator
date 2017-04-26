using BatCatTracks.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BatCatTracks
{
	public class TrackChecker
	{
		private List<Unit> RareUnits;

		public List<Unit> AllUnits;
		public Dictionary<int, List<Unit>> EventUnits;

		public List<RarityRange> Uberfest;
		public List<RarityRange> FivePercent;
		public List<RarityRange> ThreePercent;
		public Dictionary<string, List<RarityRange>> RarityRates = new Dictionary<string, List<RarityRange>>();

		public List<GatchaEvent> Events = new List<GatchaEvent>();

		public int currentSeed;

		public bool AbortCalculation = false;

		#region Initialization
		public TrackChecker()
		{
			LoadUnitData();
			LoadEventData();
			LoadRarityRanges();
			SetupCommonEvents();
			LoadRares();
		}

		private void LoadRarityRanges()
		{
			// TODO: set based on selected event
			Uberfest = new List<RarityRange>();
			var range = new RarityRange { Rarity = Rarity.Rare, Min = 0, Max = 6499 };
			Uberfest.Add(range);
			range = new RarityRange { Rarity = Rarity.SuperRare, Min = 6500, Max = 9099 };
			Uberfest.Add(range);
			range = new RarityRange { Rarity = Rarity.UberRare, Min = 9100, Max = 9999 };
			Uberfest.Add(range);

			FivePercent = new List<RarityRange>();
			range = new RarityRange { Rarity = Rarity.Rare, Min = 0, Max = 7499 };
			FivePercent.Add(range);
			range = new RarityRange { Rarity = Rarity.SuperRare, Min = 7500, Max = 9499 };
			FivePercent.Add(range);
			range = new RarityRange { Rarity = Rarity.UberRare, Min = 9500, Max = 9999 };
			FivePercent.Add(range);

			ThreePercent = new List<RarityRange>();
			range = new RarityRange { Rarity = Rarity.Rare, Min = 0, Max = 7499 };
			ThreePercent.Add(range);
			range = new RarityRange { Rarity = Rarity.SuperRare, Min = 7500, Max = 9699 };
			ThreePercent.Add(range);
			range = new RarityRange { Rarity = Rarity.UberRare, Min = 9700, Max = 9999 };
			ThreePercent.Add(range);

			RarityRates.Add("Three", ThreePercent);
			RarityRates.Add("Five", FivePercent);
			RarityRates.Add("Nine", Uberfest);
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
				var fields = line.Split(',');
				if (fields != null && fields.Length >= 3)
				{
					var unit = new Unit { Id = int.Parse(fields[0]), Name = fields[1] };
					Rarity rarity;
					Enum.TryParse<Rarity>(fields[2], out rarity);
					unit.Rarity = rarity;

					AllUnits.Add(unit);
				}
			}
		}

		private void LoadEventData()
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

		private void SetupCommonEvents()
		{
			// 160 = normal almighties
			// 154 = ultrasouls
			// 173 = ultrafest
			// 168 = uberfest
			// 167 = air
			// 166 = red

			GatchaEvent evt = new GatchaEvent
			{
				Id = 160,
				Name = "Almighties",
				RarityRate = FivePercent
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = 154,
				Name = "Ultra Souls",
				RarityRate = FivePercent
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = 166,
				Name = "Red Busters",
				RarityRate = FivePercent
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = 167,
				Name = "Air Busters",
				RarityRate = FivePercent
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = 168,
				Name = "Uberfest",
				RarityRate = Uberfest
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);

			evt = new GatchaEvent
			{
				Id = 173,
				Name = "Ultrafest",
				RarityRate = Uberfest
			};
			evt.Units = EventUnits[evt.Id];
			Events.Add(evt);
		}

		private void LoadRares()
		{
			string rares = "198,197,149,148,147,146,145,58,56,55,52,51,50,49,48,47,46,41,38,37,308,325";

			RareUnits = ConvertIdsToUnits(rares);
		}
		#endregion //Initialization

		public Task<int> FindSeedAsync(List<Unit> expected, List<Unit> eventUnits, List<RarityRange> rarities)
		{
			return Task.Run(() => FindSeed(expected, eventUnits, rarities));
		}

		public int FindSeed(List<Unit> expectedUnits, List<Unit> eventUnits, List<RarityRange> rarities)
		{
			AbortCalculation = false;
			Dictionary<Rarity, Unit[]> eventDict = CreateRarityDict(eventUnits);

			List<Unit> bestList = new List<Unit>();
			int bestSeed = 0;
			var randomUnits = new Unit[expectedUnits.Count];
			var mapping = BuildRarityMapping(rarities);
			int index = 0, seed;

			for (int startSeed = int.MinValue; startSeed < int.MaxValue; startSeed++)
			{
				if (AbortCalculation)
				{
					AbortCalculation = false;
					return 0;
				}

				currentSeed = startSeed;

				// Skip 0
				if (startSeed == 0)
					continue;

				seed = startSeed;
				index = 0;
				bool matched = false;

				do
				{
					randomUnits[index] = GetNextUnit(ref seed, mapping, eventDict);
					matched = randomUnits[index].Id == expectedUnits[index].Id
						// Battle Cats avoids having back-to-back duplicate rares - the next check is a workaround for that
						|| (index > 0
							&& randomUnits[index - 1].Id == expectedUnits[index - 1].Id
							&& expectedUnits[index].Rarity == Rarity.Rare
							&& expectedUnits[index - 1].Rarity == Rarity.Rare
							&& randomUnits[index].Id == randomUnits[index - 1].Id);
					index++;
				} while (index < expectedUnits.Count && matched);

				if (index == expectedUnits.Count && randomUnits.Last() == expectedUnits.Last())
				{
					bestSeed = startSeed;
					break;
				}
				else if (index - 1 > bestList.Count)
				{
					bestSeed = startSeed;
					bestList = randomUnits.Take(index - 1).ToList();
				}
			}

			AbortCalculation = false;

			if (index < expectedUnits.Count)
				return 0;

			return bestSeed;
		}

		public List<Unit> GetUnits(int seed, int count, List<Unit> eventUnits, List<RarityRange> rarities, bool swapTracks = false)
		{
			if (swapTracks)
				seed = UpdateSeed(seed);

			var result = new List<Unit>();
			var mapping = BuildRarityMapping(rarities);
			var rarityDict = CreateRarityDict(eventUnits);
			int oldSeed;
			for (int i = 0; i < count; i++)
			{
				oldSeed = seed;
				result.Add(new Unit(GetNextUnit(ref seed, mapping, rarityDict)));
				result[i].Seed = oldSeed;
			}

			return result;
		}

		public List<Unit> ConvertIdsToUnits(string list)
		{
			var unitIds = list.Split(',');

			List<Unit> result = new List<Unit>(unitIds.Length);

			for (int i = 0; i < unitIds.Length; i++)
			{
				result.Add(AllUnits.Single(l => l.Id == Convert.ToInt32(unitIds[i])));
			}

			return result;
		}

		#region Private methods
		private static Dictionary<Rarity, Unit[]> CreateRarityDict(List<Unit> eventUnits)
		{
			return new Dictionary<Rarity, Unit[]>
			{
				{ Rarity.Rare, eventUnits.Where(u => u.Rarity == Rarity.Rare).ToArray() },
				{ Rarity.SuperRare, eventUnits.Where(u => u.Rarity == Rarity.SuperRare).ToArray() },
				{ Rarity.UberRare, eventUnits.Where(u => u.Rarity == Rarity.UberRare).ToArray() },
			};
		}

		private static Dictionary<int, Rarity> BuildRarityMapping(List<RarityRange> rarityRanges)
		{
			Dictionary<int, Rarity> rarityMapping = new Dictionary<int, Rarity>();

			for (int i = 0; i < 10000; i++)
			{
				rarityMapping[i] = rarityRanges.Single(r => r.Min <= i && r.Max >= i).Rarity;
			}

			return rarityMapping;
		}

		private Unit GetNextUnit(ref int seed, Dictionary<int, Rarity> rarityMapping, Dictionary<Rarity, Unit[]> unitDict)
		{
			seed = UpdateSeed(seed);
			Rarity rarity = GetRarity(seed, rarityMapping);
			seed = UpdateSeed(seed);
			return GetUnit(seed, rarity, unitDict);
		}

		private static Rarity GetRarity(int seed, Dictionary<int, Rarity> rarityMapping)
		{
			int rnd = Math.Abs(seed) % 10000;

			return rarityMapping[rnd];
		}

		private Unit GetUnit(int seed, Rarity rarity, Dictionary<Rarity, Unit[]> eventUnits)
		{
			var availableUnits = eventUnits[rarity];

			int rnd = Math.Abs(seed) % availableUnits.Length;

			return availableUnits[rnd];
		}

		private static int UpdateSeed(int x)
		{
			x ^= x << 13;
			x ^= x >> 17;
			x ^= x << 15;

			return x;
		}
		#endregion
	}
}
