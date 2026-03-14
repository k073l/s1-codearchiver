using System.Collections.Generic;
using ScheduleOne.Management;
using ScheduleOne.Management.UI;
using UnityEngine;

namespace ScheduleOne.UI.Management;
public class CauldronConfigPanel : ConfigPanel
{
    [Header("References")]
    public ObjectFieldUI DestinationUI;
    protected override void BindInternal(List<EntityConfiguration> configs);
}