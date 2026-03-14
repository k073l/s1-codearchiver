using ScheduleOne.Core.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class TPEquippedUmbrella : TPEquippedItem
{
    public MeshRenderer[] CanopyMeshes;
    public SkinnedMeshRenderer[] CanopySkinnedMeshes;
    public unsafe override void Equip(IEquippedItemHandler handler);
}