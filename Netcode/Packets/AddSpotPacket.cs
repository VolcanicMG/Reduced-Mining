using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace DoubleOreDrop.Netcode.Packets
{
	public class AddSpotPacket : SpotPacket
	{
		public AddSpotPacket() : base() { }

		public AddSpotPacket(Point16 spot) : base(spot) { }

		public override void PostReceiveSpot(BinaryReader reader, Point16 recvSpot, int sender)
		{
			DoubleOreDropWorld.TryAddSpot(recvSpot);

			//broadcast to other clients
			if (Main.netMode == NetmodeID.Server)
			{
				//send to everyone but the client (he already called TryAddSpot)
				new AddSpotPacket(recvSpot).Send(from: sender);
			}
		}
	}
}
