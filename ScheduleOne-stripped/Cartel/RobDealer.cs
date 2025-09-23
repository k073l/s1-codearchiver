using System.Linq;
using FishNet;
using ScheduleOne.Economy;
using ScheduleOne.Map;
using UnityEngine;

namespace ScheduleOne.Cartel;
public class RobDealer : CartelActivity
{
    public override bool IsRegionValidForActivity(EMapRegion region);
    private Dealer GetDealerToRob(EMapRegion region);
    public override void Activate(EMapRegion region);
}