using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Equipping;
public class FlashlightAvatarEquippable : AvatarEquippable
{
    public OptimizedLight Light;
    private Vector3 lightOffset;
    public override void Equip(Avatar _avatar);
    public override void Unequip();
    private void OnEnable();
    private void LateUpdate();
    private void UpdateLightPosition();
}