using Steamworks;
using UnityEngine;

namespace ScheduleOne.Platform;
public class PlatformFriends
{
    public static Texture2D GetAvatarTexture(string id);
    public static bool IsLocalPlayerFriendsWith(string otherPlayerID);
}