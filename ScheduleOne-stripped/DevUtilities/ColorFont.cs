using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
[CreateAssetMenu(fileName = "ColorFont", menuName = "ScriptableObjects/Fonts/ColorFont", order = 1)]
public class ColorFont : ScriptableObject
{
    [Serializable]
    public class ColorFontItem
    {
        public string Name;
        public Color Colour;
    }

    [SerializeField]
    private List<ColorFontItem> ColorFontItems;
    public Color GetColour(string name);
}