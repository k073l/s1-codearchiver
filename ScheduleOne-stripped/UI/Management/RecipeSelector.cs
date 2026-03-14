using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Management;
using ScheduleOne.StationFramework;
using ScheduleOne.UI.Stations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Management;
public class RecipeSelector : ClipboardScreen
{
    [Header("References")]
    public RectTransform OptionContainer;
    public TextMeshProUGUI TitleLabel;
    public GameObject OptionPrefab;
    [Header("Settings")]
    public Sprite EmptyOptionSprite;
    private Coroutine lerpRoutine;
    private List<StationRecipe> options;
    private StationRecipe selectedOption;
    private List<RectTransform> optionButtons;
    private Action<StationRecipe> optionCallback;
    private UIContentPanel panel;
    public void Initialize(string selectionTitle, List<StationRecipe> _options, StationRecipe _selectedOption = null, Action<StationRecipe> _optionCallback = null);
    public override void Open();
    public override void Close();
    private void ButtonClicked(StationRecipe option);
    private void CreateOptions(List<StationRecipe> options);
    private void DeleteOptions();
}