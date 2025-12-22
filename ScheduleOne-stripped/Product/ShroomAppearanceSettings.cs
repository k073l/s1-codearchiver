using System;
using UnityEngine;

namespace ScheduleOne.Product;
[Serializable]
public class ShroomAppearanceSettings
{
    public static readonly Color32 DefaultPrimaryColor;
    public static readonly Color32 DefaultSecondaryColor;
    public static readonly Color32 DefaultSpotsColor;
    public Color32 PrimaryColor { get; private set; }
    public Color32 SecondaryColor { get; private set; }
    public bool HasSpots { get; private set; }
    public Color32 SpotsColor { get; private set; }

    public ShroomAppearanceSettings(Color32 primary, Color32 secondary, bool hasSpots, Color32 spotsColor);
    public ShroomAppearanceSettings();
    public bool IsUnintialized();
}