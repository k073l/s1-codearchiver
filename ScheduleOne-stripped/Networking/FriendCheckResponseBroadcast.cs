using FishNet.Broadcast;

namespace ScheduleOne.Networking;
public struct FriendCheckResponseBroadcast : IBroadcast
{
    public ulong SenderSteamId;
    public ulong TargetSteamId;
    public bool IsFriend;
}