using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.Management;
public class LabOvenUIElement : WorldspaceUIElement
{
    public LabOven AssignedOven { get; protected set; }

    public void Initialize(LabOven oven);
    protected virtual void RefreshUI();
}