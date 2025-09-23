using ScheduleOne.Economy;
using UnityEngine;

namespace ScheduleOne.Doors;
public class DealerStaticDoor : StaticDoor
{
    public Dealer Dealer;
    protected override bool IsKnockValid(out string message);
}