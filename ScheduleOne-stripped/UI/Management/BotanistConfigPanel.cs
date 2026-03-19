using System.Collections.Generic;
using ScheduleOne.Management;
using ScheduleOne.Management.UI;
using UnityEngine;

namespace ScheduleOne.UI.Management;
public class BotanistConfigPanel : ConfigPanel
{
    [Header("References")]
    public ObjectFieldUI BedUI;
    public ObjectFieldUI SuppliesUI;
    public ObjectListFieldUI PotsUI;
    protected override void BindInternal(List<EntityConfiguration> configs);
}