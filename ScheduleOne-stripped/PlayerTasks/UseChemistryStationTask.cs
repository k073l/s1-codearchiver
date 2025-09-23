using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.StationFramework;
using ScheduleOne.UI.Stations;
using ScheduleOne.Variables;
using UnityEngine;

namespace ScheduleOne.PlayerTasks;
public class UseChemistryStationTask : Task
{
    public const float STIR_TIME;
    public const float TEMPERATURE_TIME;
    private Beaker beaker;
    private StirringRod stirringRod;
    private List<StationItem> items;
    private List<IngredientPiece> ingredientPieces;
    private float stirProgress;
    private float timeInTemperatureRange;
    private ItemInstance[] RemovedIngredients;
    public ChemistryStation.EStep CurrentStep { get; private set; }
    public ChemistryStation Station { get; private set; }
    public StationRecipe Recipe { get; private set; }

    public static string GetStepDescription(ChemistryStation.EStep step);
    public UseChemistryStationTask(ChemistryStation station, StationRecipe recipe);
    public override void Update();
    private void UpdateInstruction();
    private void CheckProgress();
    private void ProgressStep();
    private void CheckStep_CombineIngredients();
    private void CheckStep_StirMixture();
    private void CheckStep_LowerBoilingFlask();
    private void CheckStep_PourIntoBoilingFlask();
    private void CheckStep_RaiseBoilingFlask();
    private void CheckStep_StartHeat();
    public override void Success();
    public override void StopTask();
}