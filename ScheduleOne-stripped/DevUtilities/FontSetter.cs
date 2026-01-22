using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.DevUtilities;
public class FontSetter : MonoBehaviour
{
    [Serializable]
    public class ImageItem
    {
        public string Name;
        public Image Image;
    }

    [Header("Components")]
    [SerializeField]
    private List<ImageItem> _imageItems;
    [Header("Fonts")]
    [SerializeField]
    private ColorFont _colourFont;
    public void SetColour(string componentName, string ColourName);
}