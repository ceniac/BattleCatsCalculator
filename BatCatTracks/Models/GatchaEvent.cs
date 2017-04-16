using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatCatTracks.Models
{
	public class GatchaEvent
	{
		public int Id;
		public string Name;
		public List<RarityRange> RarityRate;
		public List<Unit> Units;
	}
}
