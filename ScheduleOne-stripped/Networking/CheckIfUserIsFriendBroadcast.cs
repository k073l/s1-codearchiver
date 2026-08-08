using FishNet.Broadcast;

namespace ScheduleOne.Networking;
public struct CheckIfUserIsFriendBroadcast : IBroadcast
{
    public ulong SteamId;
}