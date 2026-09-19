using System.Collections.Generic;

namespace ScheduleOne.EntityFramework;
public class FloorItem : GridItem
{
    private bool NetworkInitialize___EarlyScheduleOne_002EEntityFramework_002EFloorItemAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EEntityFramework_002EFloorItemAssembly_002DCSharp_002Edll_Excuted;
    public override bool CanShareTileWith(List<GridItem> obstacles);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}