using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.Management;
public class CauldronUIElement : WorldspaceUIElement
{
    public Cauldron AssignedCauldron { get; protected set; }

    public void Initialize(Cauldron cauldron);
    protected virtual void RefreshUI();
}