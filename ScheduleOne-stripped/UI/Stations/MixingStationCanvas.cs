using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks.Tasks;
using ScheduleOne.Product;
using ScheduleOne.Properties;
using ScheduleOne.StationFramework;
using ScheduleOne.UI.Compass;
using ScheduleOne.UI.Items;
using ScheduleOne.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Stations;
public class MixingStationCanvas : Singleton<MixingStationCanvas>
{
    [Header("Prefabs")]
    public StationRecipeEntry RecipeEntryPrefab;
    [Header("References")]
    public Canvas Canvas;
    public RectTransform Container;
    public ItemSlotUI ProductSlotUI;
    public TextMeshProUGUI ProductPropertiesLabel;
    public ItemSlotUI IngredientSlotUI;
    public TextMeshProUGUI IngredientProblemLabel;
    public ItemSlotUI PreviewSlotUI;
    public Image PreviewIcon;
    public TextMeshProUGUI PreviewLabel;
    public RectTransform UnknownOutputIcon;
    public TextMeshProUGUI PreviewPropertiesLabel;
    public ItemSlotUI OutputSlotUI;
    public TextMeshProUGUI InstructionLabel;
    public RectTransform TitleContainer;
    public RectTransform MainContainer;
    public Button BeginButton;
    public RectTransform ProductHint;
    public RectTransform MixerHint;
    private StationRecipe selectedRecipe;
    public bool isOpen { get; protected set; }
    public MixingStation MixingStation { get; protected set; }

    protected override void Awake();
    protected override void Start();
    private void Exit(ExitAction action);
    protected virtual void Update();
    private void UpdateUI();
    private void UpdateInput();
    public void Open(MixingStation station);
    public void Close(bool enablePlayerControl = true);
    private void MixingDone();
    private void StationContentsChanged();
    private void UpdateDisplayMode();
    private void UpdateInstruction();
    private void UpdatePreview();
    private string GetPropertyListString(List<ScheduleOne.Properties.Property> properties);
    private string GetPropertyString(ScheduleOne.Properties.Property property);
    private List<ScheduleOne.Properties.Property> GetOutputProperties(ProductDefinition product, PropertyItemDefinition mixer);
    private bool IsOutputKnown(out ProductDefinition knownProduct);
    private void UpdateBeginButton();
    public void BeginButtonPressed();
    public void StartMixOperation(MixOperation mixOperation);
    private void MixNamed(string mixName);
}