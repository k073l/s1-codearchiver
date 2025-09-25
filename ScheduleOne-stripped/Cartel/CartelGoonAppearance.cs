using System;
using UnityEngine;

namespace ScheduleOne.Cartel;
[Serializable]
public class CartelGoonAppearance
{
    public bool IsMale;
    public int BaseAppearanceIndex;
    public Color SkinColor;
    public Color HairColor;
    public int ClothingIndex;
    public int VoiceIndex;
    public CartelGoonAppearance(bool isMale, int baseAppearanceIndex, Color skinColor, Color hairColor, int clothingIndex, int voiceIndex);
    public CartelGoonAppearance();
}