using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.Management;
public class BrickPressUIElement : WorldspaceUIElement
{
    public BrickPress AssignedPress { get; protected set; }

    public void Initialize(BrickPress press);
    protected virtual void RefreshUI();
}