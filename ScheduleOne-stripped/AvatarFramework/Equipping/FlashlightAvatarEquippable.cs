using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Equipping;
public class FlashlightAvatarEquippable : AvatarEquippable
{
    public OptimizedLight Light;
    public override void Equip(Avatar _avatar);
}