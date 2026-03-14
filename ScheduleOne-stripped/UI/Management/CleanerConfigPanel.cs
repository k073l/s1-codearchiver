using System.Collections.Generic;
using ScheduleOne.Management;
using ScheduleOne.Management.UI;
using UnityEngine;

namespace ScheduleOne.UI.Management;
public class CleanerConfigPanel : ConfigPanel
{
    [Header("References")]
    public ObjectFieldUI BedUI;
    public ObjectListFieldUI BinsUI;
    protected override void BindInternal(List<EntityConfiguration> configs);
}