using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.Management;
public class MixingStationUIElement : WorldspaceUIElement
{
    public MixingStation AssignedStation { get; protected set; }

    public void Initialize(MixingStation station);
    protected virtual void RefreshUI();
}