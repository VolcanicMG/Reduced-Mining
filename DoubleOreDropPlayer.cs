using Terraria.ModLoader;

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