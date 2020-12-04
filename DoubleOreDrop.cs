using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoubleOreDrop
{
	public class DoubleOreDrop : Mod
	{
		public static float DropChance;
		public static float MiningSpeed;
		public static float DropChance3;

		public static Dictionary<int, int> oreTileToItem;
		public static Dictionary<int, int> oreItemToTile;

		public override void Load()
		{
			oreTileToItem = new Dictionary<int, int>();
			oreItemToTile = new Dictionary<int, int>();
		}

		public override void Unload()
		{
			oreTileToItem = null;
			oreItemToTile = null;

			DoubleOreDropWorld.placedSpots = null;
		}

		public override void PostSetupContent()
		{
			for (int item = 0; item < ItemLoader.ItemCount; item++)
			{
				Item test = new Item();
				test.SetDefaults(item);
				int tile = test.createTile;
				if (tile > -1 && tile < TileLoader.TileCount && TileID.Sets.Ore[tile])
				{
					if (!oreTileToItem.ContainsKey(tile))
					{
						oreTileToItem.Add(tile, item);
					}

					if (!oreItemToTile.ContainsKey(item))
					{
						oreItemToTile.Add(item, tile);
					}
				}
			}
		}
	}
}