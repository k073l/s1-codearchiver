using UnityEngine;

namespace ScheduleOne.Core.Equipping.Framework;
[CreateAssetMenu(fileName = "Equippable (Default Handler)", menuName = "ScheduleOne/Equipping/Equippable (Default Handler)")]
public class EquippableData : IdentifiedScriptableObject
{
    public EEquippableHand Hand;
    public FPEquippedItem FirstPersonEquippedItemPrefab;
    public TPEquippedItem ThirdPersonEquippedItemPrefab;
}