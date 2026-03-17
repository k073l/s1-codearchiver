using System;
using ScheduleOne.Core.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.Equipping;
public class TPEquippedUmbrella : TPEquippedItem
{
    public MeshRenderer[] CanopyMeshes;
    public SkinnedMeshRenderer[] CanopySkinnedMeshes;
    private Random _random;
    public unsafe override void Equip(IEquippedItemHandler handler);
}