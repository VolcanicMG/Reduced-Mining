
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;

namespace DoubleOreDrop
{	
	[Label("Reduced Mining Config")]
	public class DoubleOreDropConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide; //Change to client to make it only applicable to the client side

		[Header("Reduced Mining Ore Drop Chance")]
		[Label("Set Ore Drop Chance; Current Chance")]
		[Tooltip("0 = '0% or Off', 1 = '100%'")]
		[Increment(0.1f)]
		[Range(0f, 1f)]
		[DefaultValue(.2f)]
		[Slider]
		public float DropChance;

		[Header("Increase or Reduce Mining Speed")]
		[Label("Increase/Decreas; Current Increase/Decrease %")]
		[Tooltip("-3 = '-300% Decrease', 3 = '300% Increase'")]
		[Increment(0.1f)]
		[Range(-3f, 3f)]
		[DefaultValue(.2f)]
		[Slider]
		public float MiningSpeed;

		public override void OnChanged()
		{
			DoubleOreDrop.DropChance = DropChance;
			DoubleOreDrop.MiningSpeed = -MiningSpeed;
		}
	}
}