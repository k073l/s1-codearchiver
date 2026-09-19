using System;
using UnityEngine;

namespace ScheduleOne.Core.Avatar;
[Serializable]
[CreateAssetMenu(fileName = "Outfit", menuName = "ScheduleOne/Avatar/Outfit", order = 1)]
public class Outfit : ScriptableObject
{
    public SerializedAvatarObject[] AvatarObjects;
}