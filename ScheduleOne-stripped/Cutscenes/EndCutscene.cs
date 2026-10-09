using ScheduleOne.AvatarFramework;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Cutscenes;
public class EndCutscene : Cutscene
{
    public UnityEvent onStandUp;
    public UnityEvent onRunStart;
    public UnityEvent onEngineStart;
    public UnityEvent onLightsOn;
    public ScheduleOne.AvatarFramework.Avatar Avatar;
    private void Start();
    public void StandUp();
    public void RunStart();
    public void EngineStart();
    public void LightsOn();
    public void On3rdPerson();
}