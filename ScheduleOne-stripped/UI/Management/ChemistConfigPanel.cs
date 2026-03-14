using System.Collections.Generic;
using ScheduleOne.Management;
using ScheduleOne.Management.UI;
using UnityEngine;

namespace ScheduleOne.UI.Management;
public class ChemistConfigPanel : ConfigPanel
{
    [Header("References")]
    public ObjectFieldUI BedUI;
    public ObjectListFieldUI StationsUI;
    protected override void BindInternal(List<EntityConfiguration> configs);
}