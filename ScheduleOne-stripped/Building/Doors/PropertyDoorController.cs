using ScheduleOne.Doors;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Police;
using ScheduleOne.Property;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Building.Doors;
public class PropertyDoorController : DoorController
{
    public const float WANTED_PLAYER_CLOSE_DISTANCE;
    public ScheduleOne.Property.Property Property;
    private bool IsUnlocked;
    private bool NetworkInitialize___EarlyScheduleOne_002EBuilding_002EDoors_002EPropertyDoorControllerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EBuilding_002EDoors_002EPropertyDoorControllerAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    public void Unlock();
    private void CheckClose();
    protected override bool CanPlayerAccess(EDoorSide side, out string reason);
    private Player GetNearestWantedPlayer();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002EBuilding_002EDoors_002EPropertyDoorController_Assembly_002DCSharp_002Edll();
}