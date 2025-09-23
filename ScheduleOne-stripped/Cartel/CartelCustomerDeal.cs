using System;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.Map;
using UnityEngine;

namespace ScheduleOne.Cartel;
public class CartelCustomerDeal : CartelActivity
{
    public const int TIMEOUT_MINUTES;
    private CartelDealer dealer;
    public override bool IsRegionValidForActivity(EMapRegion region);
    public override void Activate(EMapRegion region);
    protected override void MinPassed();
    protected override void Deactivate();
}