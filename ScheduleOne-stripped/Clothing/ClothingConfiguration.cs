using System;
using System.Collections.Generic;
using ScheduleOne.Configuration;
using UnityEngine;

namespace ScheduleOne.Clothing;
[CreateAssetMenu(fileName = "ClothingConfiguration", menuName = "ScheduleOne/Configurations/Clothing Configuration")]
public class ClothingConfiguration : Configuration<ClothingSettings>
{
    [Serializable]
    public struct ColorData
    {
        public EClothingColor ColorType;
        public Color ActualColor;
        public Color LabelColor;
        public bool IsNull();
    }

    [Serializable]
    public struct ClothingSlotData
    {
        public EClothingSlot Slot;
        public string Name;
        public Sprite Icon;
        public bool IsNull();
    }

    [SerializeField]
    protected List<ColorData> _colorData;
    [SerializeField]
    protected List<ClothingSlotData> _slotData;
    public override void ValidateConfiguration();
    public ColorData GetColorData(EClothingColor color);
    public ClothingSlotData GetSlotData(EClothingSlot slot);
}