using System;
using System.Collections.Generic;
using ScheduleOne.Clothing;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.CharacterCreator;
public class CharacterCreatorColorSelector : MonoBehaviour
{
    private static EClothingColor[] ClothingColors;
    [Header("References")]
    public RectTransform OptionContainer;
    [Header("Settings")]
    public bool UseClothingColors;
    public List<Color> Colors;
    public GameObject OptionPrefab;
    private Color _value;
    private List<Button> _optionButtons;
    private Button _selectedButton;
    public event Action<Color> OnColorSelected;
    private void Awake();
    public void SetColor(Color color);
    private void OptionClicked(Color color);
}