using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader.Config;

namespace DoubleOreDrop
{	
	[Label("Reduced Mining Config")]
	public class DoubleOreDropConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide; //Change to client to make it only applicable to the client side
		//DropChance won't work if clientside, because Drop() is called serverside.
		//if MiningSpeed is clientside, it will desync in multiplayer for different values

		[Header("Reduced Mining Ore Drop Chance")]
		[Label("Set Ore Drop Chance; Current Chance")]
		[Tooltip("0 = '0% or Off', 1 = '100%'")]
		[Increment(0.1f)]
		[Range(0f, 1f)]
		[DefaultValue(.2f)]
		[Slider]
		public float DropChance;

		[Header("Increase or Decrease Mining Speed")]
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
		}

		//For when someone edits the config file directly
		[OnDeserialized]
		internal void OnDeserializedMethod(StreamingContext context)
        {
			DropChance = Utils.Clamp(DropChance, 0f, 1f);
			MiningSpeed = Utils.Clamp(MiningSpeed, -3f, 3f);
		}
	}
}