using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatCatTracks.Models
{
	public class Unit
	{
		public Unit() { }

		public Unit(Unit other)
		{
			Id = other.Id;
			Seed = 0;
			Name = other.Name;
			Rarity = other.Rarity;
		}

		public int Id { get; set; }
		public int Seed { get; set; }
		public string Name { get; set; }
		public Rarity Rarity { get; set; }

		public override string ToString()
		{
			return Rarity + ":" + Name;
		}
	}

	public enum Rarity
	{
		Normal = 0,
		Special = 1,
		Rare = 2,
		SuperRare = 3,
		UberRare = 4
	}
}
