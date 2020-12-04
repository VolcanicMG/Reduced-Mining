using System.Collections.Generic;
using System.Linq;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoubleOreDrop
{
	public class DoubleOreDropWorld : ModWorld
	{
		//HashSet because .Contains checks are incredibly fast with it
		public static HashSet<Point16> placedSpots;

		public override void Initialize()
		{
			placedSpots = new HashSet<Point16>();
		}

		public override TagCompound Save()
		{
			//Because tml TagCompound doesn't support HashSet<Point16>, we have to do some conversions here to List<Point16>
			int count = placedSpots.Count;
			if (count == 0) return null;

			Point16[] Point16Array = new Point16[count];
			placedSpots.CopyTo(Point16Array);

			List<Point16> Point16List = Point16Array.ToList();

			return new TagCompound
			{
				{"placedSpots", Point16List}
			};
		}

		public override void Load(TagCompound tag)
		{
			//Because tml TagCompound doesn't support HashSet<Point16>, we have to do some conversions here from List<Point16>

			var Point16IList = tag.GetList<Point16>("placedSpots");
			placedSpots = new HashSet<Point16>(Point16IList);
		}
	}
}