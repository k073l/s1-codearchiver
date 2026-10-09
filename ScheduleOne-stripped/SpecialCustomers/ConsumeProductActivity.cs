using System.Collections.Generic;
using ScheduleOne.NPCs;
using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers;
public class ConsumeProductActivity : SpecialCustomerActivity
{
    public override string ActivityName => "Consume Product";
    protected override int MaxParticipantsPerInstance => 3;
    protected override bool ShouldBeConsideredForReassignment => false;

    protected override void OnRun(List<SpecialCustomer> npcs);
    public override Vector2Int GetMinMaxParticipants();
    public override bool CanStart();
    private ProductItemInstance GetProduct();
}