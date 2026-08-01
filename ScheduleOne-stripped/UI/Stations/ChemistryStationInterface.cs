using System;
using System.Collections.Generic;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.StationFramework;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Stations;
public class ChemistryStationInterface : StationInterface<ChemistryStationInterface>
{
    public List<StationRecipe> Recipes;
    [Header("Prefabs")]
    public StationRecipeEntry RecipeEntryPrefab;
    [Header("References")]
    public ItemSlotUI[] InputSlotUIs;
    public ItemSlotUI OutputSlotUI;
    public RectTransform RecipeSelectionContainer;
    public RectTransform SelectedRecipeIndicator;
    public TextMeshProUGUI InstructionLabel;
    public TextMeshProUGUI ErrorLabel;
    public Button BeginButton;
    public RectTransform RecipeContainer;
    public RectTransform CookingInProgressContainer;
    public StationRecipeEntry InProgressRecipeEntry;
    private List<StationRecipeEntry> recipeEntries;
    private StationRecipeEntry selectedRecipe;
    public ChemistryStation ChemistryStation { get; protected set; }

    protected override void Awake();
    protected virtual void Update();
    private void LateUpdate();
    private void UpdateUI();
    private void UpdateInput();
    public void Open(ChemistryStation station);
    public void Close();
    private void BeginTask();
    private void StationSlotsChanged();
    private void SortRecipes(List<ItemInstance> ingredients);
    private void SetSelectedRecipe(StationRecipeEntry entry);
}