using System.Collections.Generic;
using ScheduleOne.Core.Avatar;
using UnityEngine;

namespace ScheduleOne.Avatar;
public static class AvatarObjectLibrary
{
    private const string AvatarObjectsResourcesPath;
    private static Dictionary<string, AvatarObject> _avatarObjects;
    [RuntimeInitializeOnLoadMethod( /*Could not decode attribute arguments.*/)]
    public static void Initialize();
    private static void DiscoverAvatarObjects();
    public static List<AvatarObject> GetAllAvatarObjects();
    public static bool TryGetAvatarObjectById(string id, out AvatarObject avatarObject);
    public static AvatarObject GetAvatarObjectById(string id);
    public static bool TryGetAvatarObjectById<T>(string id, out T avatarObject)
        where T : AvatarObject;
}