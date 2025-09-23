using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class Equippable_AvatarViewmodel : Equippable_Viewmodel
{
    public RuntimeAnimatorController AnimatorController;
    public Vector3 ViewmodelAvatarOffset;
    public Vector3 ViewmodelAvatarRotationOffset;
    [Header("Equipping")]
    public float EquipTime;
    public string EquipTrigger;
    protected float timeEquipped;
    protected bool equipAnimDone => timeEquipped >= EquipTime;

    public override void Equip(ItemInstance item);
    public override void Unequip();
    protected override void PlayEquipAnimation();
    protected override void Update();
}