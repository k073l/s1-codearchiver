using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using ScheduleOne.StationFramework;
using ScheduleOne.UI.Stations;
using UnityEngine;

namespace ScheduleOne.PlayerTasks;
public class StartLabOvenTask : Task
{
    public enum EStep
    {
        OpenDoor,
        Pour,
        CloseDoor,
        PressButton
    }

    private ItemInstance ingredient;
    private Coroutine pourRoutine;
    private StationItem stationItem;
    private PourableModule pourableModule;
    private bool pourAnimDone;
    public LabOven Oven { get; private set; }
    public EStep CurrentStep { get; protected set; }

    public StartLabOvenTask(LabOven oven);
    public override void Update();
    public override void Success();
    public override void StopTask();
    private void CheckProgress();
    private void ProgressStep();
    private void CheckStep_OpenDoor();
    private void CheckStep_Pour();
    private void CheckStep_CloseDoor();
    private void CheckStep_PressButton();
    private IEnumerator PlayPourAnimation();
    public static string GetStepInstruction(EStep step);
}