
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

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
            if (Main.rand.NextFloat() <= DoubleOreDrop.DropChance)
            {
                if (Terraria.ID.TileID.Sets.Ore[type] && !(TileLoader.GetTile(type) is ModTile)) //Vanilla
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, OreDrops[type], 1, false, -1, false, false);
                }

                if (TileLoader.GetTile(type) is ModTile && TileLoader.GetTile(type).Name.Contains("Ore")) //Modded
                {
                    ModTile tile = TileLoader.GetTile(type);

                    if (tile != null)
                    {
                        if (tile.drop > 0)
                        {
                            Item.NewItem(i * 16, j * 16, 16, 16, tile.drop, 1, false, -1, false, false);
                        }
                        return true;
                    }
                }
            }

            return true;
        }
    }
}