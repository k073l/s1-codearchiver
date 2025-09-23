using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.StationFramework;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks;
public class CauldronTask : Task
{
    public enum EStep
    {
        CombineIngredients,
        StartMixing
    }

    private StationItem[] CocaLeaves;
    private StationItem Gasoline;
    private Draggable Tub;
    public Cauldron Cauldron { get; private set; }
    public EStep CurrentStep { get; private set; }

    public static string GetStepDescription(EStep step);
    public CauldronTask(Cauldron caudron);
    public override void Success();
    public override void StopTask();
    public override void Update();
    private void CheckProgress();
    private void CheckStep_CombineIngredients();
    private void StartMixing();
    private void UpdateInstruction();
    private void StartButtonPressed();
}