
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoubleOreDrop
{
	public class DoubleOreDropPlayer : ModPlayer
	{
		public List<Vector2> dropSpotSaved;

		public override void ResetEffects()
		{
			player.pickSpeed += DoubleOreDrop.MiningSpeed;
		}

		public override void PostUpdateMiscEffects()    // Put updates to damage, knockback, crit, and radius here
		{
			player.pickSpeed += DoubleOreDrop.MiningSpeed;
		}

		public override void OnEnterWorld(Player player)
		{
			DoubleOreDrop.placedSpot.Clear();

			if (dropSpotSaved.Count >= 1)
			{
				dropSpotSaved.ForEach(Pos => DoubleOreDrop.placedSpot.Add(Pos));
				dropSpotSaved.Clear();
			}
			//Main.NewText(dropSpotSaved.Count);

			//Main.NewText(DoubleOreDrop.placedSpot.Count + " Mod");

			//Main.NewText(dropSpotSaved.Count + " Player");

			base.OnEnterWorld(player);
		}

		public override TagCompound Save()
		{
			return new TagCompound  // save tag, leave whats here add more as needed
			{
				[nameof(dropSpotSaved)] = dropSpotSaved

			};
		}

		public override void Load(TagCompound tag)
		{
			// Main tag loading
			dropSpotSaved = (List<Vector2>)tag.GetList<Vector2>(nameof(dropSpotSaved));
			base.Load(tag);
		}
	}
}