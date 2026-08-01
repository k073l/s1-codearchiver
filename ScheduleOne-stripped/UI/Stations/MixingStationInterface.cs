using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Effects;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks.Tasks;
using ScheduleOne.Product;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Stations;
public class MixingStationInterface : StationInterface<MixingStationInterface>
{
    [Header("Prefabs")]
    public StationRecipeEntry RecipeEntryPrefab;
    [Header("References")]
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
    public RectTransform MainSlotContainer;
    public Button BeginButton;
    public RectTransform ProductHint;
    public RectTransform MixerHint;
    public MixingStation Station { get; protected set; }

    protected override void Awake();
    protected virtual void Update();
    private void UpdateInput();
    public void Open(MixingStation station);
    public void Close();
    private void MixingDone();
    private void CheckForUnknownMix();
    private void StationContentsChanged();
    private void UpdateDisplayMode();
    private void UpdateInstruction();
    private void UpdatePreview();
    private string GetPropertyListString(List<Effect> properties);
    private string GetPropertyString(Effect property);
    private List<Effect> GetOutputProperties(ProductDefinition product, PropertyItemDefinition mixer);
    private void UpdateBeginButton();
    public void BeginButtonPressed();
    private void BeginTask();
    private void BeginMix();
    private void MixNamed(string mixName);
}