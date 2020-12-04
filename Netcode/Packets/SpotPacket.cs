using System.IO;
using Terraria.DataStructures;

namespace DoubleOreDrop.Netcode.Packets
{
	public abstract class SpotPacket : MPPacket
	{
		readonly Point16 spot;

		//For reflection
		public SpotPacket() { }

		public SpotPacket(Point16 spot)
		{
			this.spot = spot;
		}

		public override void Send(BinaryWriter writer)
		{
			writer.Write(spot.X);
			writer.Write(spot.Y);
		}

		public sealed override void Receive(BinaryReader reader, int sender)
		{
			short x = reader.ReadInt16();
			short y = reader.ReadInt16();

			//do stuff with that
			Point16 recvSpot = new Point16(x, y);

			PostReceiveSpot(reader, recvSpot, sender);
		}

		public abstract void PostReceiveSpot(BinaryReader reader, Point16 recvSpot, int sender);
	}
}
