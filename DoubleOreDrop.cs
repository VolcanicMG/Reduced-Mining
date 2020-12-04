using Microsoft.Xna.Framework;
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

		public static List<Vector2> placedSpot;

		public override void Load()
		{
			oreTileToItem = new Dictionary<int, int>();
			oreItemToTile = new Dictionary<int, int>();

			placedSpot = new List<Vector2>();
		}

		public override void Unload()
		{
			oreTileToItem = null;
			oreItemToTile = null;

			placedSpot = null;
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

		public override void PreSaveAndQuit()
		{
			Player player = Main.player[Main.myPlayer];

			if (player.whoAmI != 255)//Don't want to get the server
			{
				player.GetModPlayer<DoubleOreDropPlayer>().dropSpotSaved = placedSpot;

			}
			base.PreSaveAndQuit();
		}
	}
}