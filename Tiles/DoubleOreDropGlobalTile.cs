using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace DoubleOreDrop.Tiles
{
    public class DoubleOreDropGlobalTile : GlobalTile
    {
        public static readonly Dictionary<int, int> OreDrops = new Dictionary<int, int>()
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
            //Easy exploit, break ore, place ore, break ore, etc
            if (WorldGen.genRand.NextFloat() <= DoubleOreDrop.DropChance)
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

            return true;
        }
    }
}