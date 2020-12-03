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

        public static List<Vector2> placedSpot;

		public static int[] oreItems;

        public override void PostSetupContent()
        {
            oreItems = new int[]
            {
                ItemID.CopperOre,
                ItemID.TinOre,
                ItemID.IronOre,
                ItemID.SilverOre,
                ItemID.TungstenOre,
                ItemID.GoldOre,
                ItemID.PlatinumOre,
                ItemID.Meteorite,
                ItemID.DemoniteOre,
                ItemID.CrimtaneOre,
                ItemID.Obsidian,
                ItemID.Hellstone,
                ItemID.CobaltOre,
                ItemID.PalladiumOre,
                ItemID.MythrilOre,
                ItemID.OrichalcumOre,
                ItemID.AdamantiteOre,
                ItemID.TitaniumOre,
                ItemID.ChlorophyteOre,
                ItemID.LunarOre,
                ItemID.LeadOre
            };

            placedSpot = new List<Vector2>();
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