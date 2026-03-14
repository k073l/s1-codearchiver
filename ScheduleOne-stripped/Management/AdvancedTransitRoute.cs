using System;
using System.Collections.Generic;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Management;
public class AdvancedTransitRoute : TransitRoute
{
    public ManagementItemFilter Filter { get; private set; } = new ManagementItemFilter(ManagementItemFilter.EMode.Blacklist);

    public AdvancedTransitRoute(ITransitEntity source, ITransitEntity destination);
    public AdvancedTransitRoute(AdvancedTransitRouteData data);
    public ItemInstance GetItemReadyToMove();
    public AdvancedTransitRouteData GetData();
}