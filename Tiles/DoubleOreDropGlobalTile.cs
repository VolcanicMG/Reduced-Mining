using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoubleOreDrop.Tiles
{
	public class DoubleOreDropGlobalTile : GlobalTile
	{
		public override bool Drop(int i, int j, int type)
		{

			Point16 spot = new Point16(i, j);
			if (!DoubleOreDropWorld.placedSpots.Contains(spot) && TileID.Sets.Ore[type]) //If the spot is not in the list then continue through the if statement
			{

				if (WorldGen.genRand.NextFloat() <= DoubleOreDrop.DropChance)
				{
					DropTheGoods(i, j, type); //drop twice

					if (WorldGen.genRand.NextFloat() <= DoubleOreDrop.DropChance3)
					{
						DropTheGoods(i, j, type); //Drop 3 times
					}
				}
			}
			else if (DoubleOreDropWorld.placedSpots.Contains(spot)) //In the list
			{
				DoubleOreDropWorld.placedSpots.Remove(spot);
			}

			return true;
		}

		public override void PlaceInWorld(int i, int j, Item item)
		{
			//Netcode - In the main class just send i and j and add it to the list there?
			if (DoubleOreDrop.oreItemToTile.ContainsKey(item.type))
			{
				Point16 spot = new Point16(i, j);
				if (!DoubleOreDropWorld.placedSpots.Contains(spot))
				{
					//Don't allow duplicates to be added
					DoubleOreDropWorld.placedSpots.Add(spot);
				}
			}
		}

		public void DropTheGoods(int i, int j, int type)
		{
			ModTile modTile = TileLoader.GetTile(type);

			if (modTile == null)
			{
				//Vanilla
				if (TileID.Sets.Ore[type] && DoubleOreDrop.oreTileToItem.TryGetValue(type, out int item))
				{
					Item.NewItem(i * 16, j * 16, 16, 16, item, 1, false, -1, false, false);
				}
			}
			else
			{
				//Modded
				//modTile.Name.Contains("Ore") is a bad way to detect if it's a modded ore. If the modder is smart he should have added his tile to TileID.Sets.Ore properly
				//If not, let the modder know of the ore that doesn't work
				if (TileID.Sets.Ore[type])
				{
					int drop = modTile.drop;
					if (drop > 0)
					{
						Item.NewItem(i * 16, j * 16, 16, 16, drop, 1, false, -1, false, false);
					}
				}
			}
		}
	}
}