using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.StationFramework;
using ScheduleOne.Trash;
using ScheduleOne.UI;
using ScheduleOne.UI.Stations;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks.Tasks;
public class UseMixingStationTask : Task
{
    public enum EStep
    {
        CombineIngredients,
        StartMixing
    }

    private List<StationItem> items;
    private List<StationItem> mixerItems;
    private List<IngredientPiece> ingredientPieces;
    private ItemInstance[] removedIngredients;
    private Beaker Jug;
    public MixingStation Station { get; private set; }
    public EStep CurrentStep { get; private set; }

    public static string GetStepDescription(EStep step);
    public UseMixingStationTask(MixingStation station);
    private Beaker CreateJug();
    public override void Update();
    private void UpdateInstruction();
    private void CheckProgress();
    private void CheckStep_CombineIngredients();
    private int GetCombinedIngredients();
    private void ProgressStep();
    private void StartButtonPressed();
    public override void Success();
    private void CreateTrash();
    public override void StopTask();
}