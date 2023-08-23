
using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader.Config;

namespace DoubleOreDrop
{
	public class DoubleOreDropConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header("OreDropChance")]
		[Increment(0.1f)]
		[Range(0f, 1f)]
		[DefaultValue(.2f)]
		[Slider]
		public float DropChance;

		[Header("TripleChance(Basedoffof'Oredropchance')")]
		[Increment(0.05f)]
		[Range(0f, 1f)]
		[DefaultValue(.05f)]
		[Slider]
		public float DropChance3;

		[Header("IncreaseorReduceMiningSpeed")]
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