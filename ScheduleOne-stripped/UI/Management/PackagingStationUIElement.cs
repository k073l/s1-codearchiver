using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.Management;
public class PackagingStationUIElement : WorldspaceUIElement
{
    public PackagingStation AssignedStation { get; protected set; }

    public void Initialize(PackagingStation pack);
    protected virtual void RefreshUI();
}