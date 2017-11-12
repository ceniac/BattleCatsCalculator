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
		public int currentSeed;

		public bool AbortCalculation = false;

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

		public List<Unit> GetUnits(int seed, int count, List<Unit> eventUnits, List<RarityRange> rarities, PullMode mode = PullMode.Normal)
		{
			if (mode == PullMode.TrackB)
				seed = UpdateSeed(seed);

			var result = new List<Unit>();
			var mapping = BuildRarityMapping(rarities);
			var rarityDict = CreateRarityDict(eventUnits);
			int oldSeed;
			for (int i = 0; i < count; i++)
			{
				if (mode != PullMode.Guaranteed || i < 10)
				{
					oldSeed = seed;
					result.Add(new Unit(GetNextUnit(ref seed, mapping, rarityDict)));
					result[i].Seed = oldSeed;
				}
				else
				{
					oldSeed = seed;
					seed = UpdateSeed(seed);
					result.Add(new Unit(GetUnit(seed, Rarity.UberRare, rarityDict)));
					seed = UpdateSeed(seed);
					result[i].Seed = oldSeed;
				}
			}

			return result;
		}

		public List<Unit> ConvertIdsToUnits(string list)
		{
			var unitIds = list.Split(',');

			List<Unit> result = new List<Unit>(unitIds.Length);

			for (int i = 0; i < unitIds.Length; i++)
			{
				result.Add(GatchaSets.Instance.AllUnits.Single(l => l.Id == Convert.ToInt32(unitIds[i])));
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
