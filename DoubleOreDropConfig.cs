
using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader.Config;

namespace DoubleOreDrop
{
	[Label("Reduced Mining Config")]
	public class DoubleOreDropConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header("Ore Drop Chance")]
		[Label("Set Ore Drop Chance; Current Chance")]
		[Tooltip("0 = '0% or Off', 1 = '100%'")]
		[Increment(0.1f)]
		[Range(0f, 1f)]
		[DefaultValue(.2f)]
		[Slider]
		public float DropChance;

		[Header("Triple Chance (Based off of 'Ore drop chance')")]
		[Label("Set Ore Drop Chance; Current Chance")]
		[Tooltip("0 = '0% or Off', 1 = '100%', 100% will drop another one depending on 'Ore Drop Chance'")]
		[Increment(0.05f)]
		[Range(0f, 1f)]
		[DefaultValue(.05f)]
		[Slider]
		public float DropChance3;

		[Header("Increase or Reduce Mining Speed")]
		[Label("Increase/Decrease; Current Increase/Decrease %")]
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
			DoubleOreDrop.DropChance3 = DropChance3;
		}

		//For when someone edits the config file directly
		[OnDeserialized]
		internal void OnDeserializedMethod(StreamingContext context)
		{
			DropChance = Utils.Clamp(DropChance, 0f, 1f);
			MiningSpeed = Utils.Clamp(MiningSpeed, -3f, 3f);
			DropChance3 = Utils.Clamp(DropChance3, 0f, 1f);
		}
	}
}