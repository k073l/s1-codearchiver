using System;
using System.Linq;
using FishNet.Broadcast;

namespace ScheduleOne.Platform;
[Serializable]
public struct SteamSessionAuthTicket : IBroadcast
{
    public byte[] Bytes;
    public uint Size;
    public ulong SteamId;
    public static SteamSessionAuthTicket Invalid => new SteamSessionAuthTicket(null, 0u, 0uL);

    public SteamSessionAuthTicket(byte[] ticket, uint size, ulong steamId);
    public override bool Equals(object obj);
    public override int GetHashCode();
}