using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Equipping.Framework;
[RequireComponent(typeof(Player))]
public class PlayerNetworkedEquipper : NetworkedEquipper
{
    private Player _player;
    private bool NetworkInitialize___EarlyScheduleOne_002EEquipping_002EFramework_002EPlayerNetworkedEquipperAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EEquipping_002EFramework_002EPlayerNetworkedEquipperAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    protected override IEquippableUser GetUser();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void Awake_UserLogic_ScheduleOne_002EEquipping_002EFramework_002EPlayerNetworkedEquipper_Assembly_002DCSharp_002Edll();
}