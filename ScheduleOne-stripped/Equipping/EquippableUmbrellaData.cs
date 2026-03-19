using ScheduleOne.Core.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.Equipping;
[CreateAssetMenu(fileName = "UmbrellaData", menuName = "ScheduleOne/Equipping/Umbrella")]
public class EquippableUmbrellaData : EquippableData
{
    public Gradient CanopyColor;
    [Header("Canopy Decal")]
    public Texture2D CanopyDecal;
    public Color CanopyDecalColor;
}