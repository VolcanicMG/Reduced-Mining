using System.IO;
using Terraria.DataStructures;

namespace DoubleOreDrop.Netcode.Packets
{
	public class RemoveSpotPacket : SpotPacket
	{
		public RemoveSpotPacket() : base() { }

		public RemoveSpotPacket(Point16 spot) : base(spot) { }

		public override void PostReceiveSpot(BinaryReader reader, Point16 recvSpot, int sender)
		{
			DoubleOreDropWorld.RemoveSpot(recvSpot);
		}
	}
}
