using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Clothing;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.CharacterCreator;
public class CharacterCreatorOptionList : CharacterCreatorField<string>
{
    [Serializable]
    public class Option
    {
        public string Label;
        public string AssetPath;
        public ClothingDefinition ClothingItemEquivalent;
    }

    [Header("References")]
    public RectTransform OptionContainer;
    [Header("Settings")]
    public bool CanSelectNone;
    public List<Option> Options;
    public GameObject OptionPrefab;
    private List<Button> optionButtons;
    private Button selectedButton;
    protected override void Awake();
    public override void ApplyValue();
    public void OptionClicked(string option);
}