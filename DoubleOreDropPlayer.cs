using Terraria.ModLoader;

namespace DoubleOreDrop
{
	public class DoubleOreDropPlayer : ModPlayer
	{
		public override void ResetEffects()
		{
			Player.pickSpeed += DoubleOreDrop.MiningSpeed;
		}

		public override void PostUpdateMiscEffects()    // Put updates to damage, knockback, crit, and radius here
		{
			Player.pickSpeed += DoubleOreDrop.MiningSpeed;
		}
	}
}