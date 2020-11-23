
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace DoubleOreDrop
{
	public class DoubleOreDropPlayer : ModPlayer
	{
        public override void ResetEffects()
        {
			player.pickSpeed += DoubleOreDrop.MiningSpeed;
		}

		public override void PostUpdateMiscEffects()    // Put updates to damage, knockback, crit, and radius here
		{
			player.pickSpeed += DoubleOreDrop.MiningSpeed;
		}
	}
}