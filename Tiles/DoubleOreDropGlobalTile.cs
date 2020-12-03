using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoubleOreDrop.Tiles
{
    public class DoubleOreDropGlobalTile : GlobalTile
    {
        Dictionary<int, int> OreDrops = new Dictionary<int, int>()
        {
            {TileID.Copper, ItemID.CopperOre},
            {TileID.Tin, ItemID.TinOre},
            {TileID.Iron, ItemID.IronOre},
            {TileID.Silver, ItemID.SilverOre},
            {TileID.Tungsten, ItemID.TungstenOre},
            {TileID.Gold, ItemID.GoldOre},
            {TileID.Platinum, ItemID.PlatinumOre},
            {TileID.Meteorite, ItemID.Meteorite},
            {TileID.Demonite, ItemID.DemoniteOre},
            {TileID.Crimtane, ItemID.CrimtaneOre},
            {TileID.Obsidian, ItemID.Obsidian},
            {TileID.Hellstone, ItemID.Hellstone},
            {TileID.Cobalt, ItemID.CobaltOre},
            {TileID.Palladium, ItemID.PalladiumOre},
            {TileID.Mythril, ItemID.MythrilOre},
            {TileID.Orichalcum, ItemID.OrichalcumOre},
            {TileID.Adamantite, ItemID.AdamantiteOre},
            {TileID.Titanium, ItemID.TitaniumOre},
            {TileID.Chlorophyte, ItemID.ChlorophyteOre},
            {TileID.LunarOre, ItemID.LunarOre},
            {TileID.Lead, ItemID.LeadOre},
        };

        public override bool Drop(int i, int j, int type)
        {

            if (!DoubleOreDrop.placedSpot.Contains(new Vector2(i, j)) && TileID.Sets.Ore[type]) //If the spot is not in the list then continue through the if statement
            {
                
                if (WorldGen.genRand.NextFloat() <= DoubleOreDrop.DropChance) 
                {
                    dropTheGoods(i, j, type); //drop twice

                    if (WorldGen.genRand.NextFloat() <= DoubleOreDrop.DropChance3)
                    {
                        dropTheGoods(i, j, type); //Drop 3 times
                    }
                }
            }
            else if(DoubleOreDrop.placedSpot.Contains(new Vector2(i, j)))//In the list
            {
                DoubleOreDrop.placedSpot.Remove(new Vector2(i, j));
                DoubleOreDrop.placedSpot.Distinct().ToList();
            }

            return true;
        }

        public override void PlaceInWorld(int i, int j, Item item)
        {
            //Netcode - In the main class just send i and j and add it to the list there?
            if (DoubleOreDrop.oreItems.Contains(item.type))
            {
                DoubleOreDrop.placedSpot.Add(new Vector2(i, j));
            }
        }

        public void dropTheGoods(int i, int j, int type)
        {
            ModTile modTile = TileLoader.GetTile(type);

            if (modTile == null)
            {
                //Vanilla
                if (TileID.Sets.Ore[type] && OreDrops.TryGetValue(type, out int item))
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