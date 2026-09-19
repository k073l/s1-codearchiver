using System;
using System.Collections.Generic;
using ScheduleOne.Clothing;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.CharacterCreator;
public class CharacterCreatorClothingSelector : MonoBehaviour
{
    [Header("References")]
    public RectTransform OptionContainer;
    [SerializeField]
    private GameObject OptionPrefab;
    [Header("Settings")]
    [SerializeField]
    private bool CanSelectNone;
    [SerializeField]
    private List<ClothingDefinition> Options;
    private List<Button> optionButtons;
    private Dictionary<Button, ClothingDefinition> buttonOptionMap;
    private ClothingDefinition _selection;
    public event Action<ClothingDefinition> OnSelectionChanged;
    protected void Awake();
    private void CreateButton(ClothingDefinition clothing);
    private void Select(ClothingDefinition selection);
    public void SetSelection(ClothingDefinition selection, bool notify);
    public void SetSelectionWithoutNotify(ClothingDefinition selection);
}