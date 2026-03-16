using ScheduleOne.DevUtilities;
using ScheduleOne.Map;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Doors;
public class SewerDoorController : DoorController
{
    private bool NetworkInitialize___EarlyScheduleOne_002EDoors_002ESewerDoorControllerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EDoors_002ESewerDoorControllerAssembly_002DCSharp_002Edll_Excuted;
    protected override bool CanPlayerAccess(EDoorSide side, out string reason);
    public override void ExteriorHandleInteracted();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}