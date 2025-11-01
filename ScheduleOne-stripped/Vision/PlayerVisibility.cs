using ScheduleOne.DevUtilities;
using ScheduleOne.Law;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Vision;
public class PlayerVisibility : EntityVisibility
{
    private Player player;
    private bool disobeyingCurfewStateApplied;
    private bool NetworkInitialize___EarlyScheduleOne_002EVision_002EPlayerVisibilityAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EVision_002EPlayerVisibilityAssembly_002DCSharp_002Edll_Excuted;
    public override float Suspiciousness { get; }

    public override void Awake();
    private void Update();
    private void AddFlag_DisobeyingCurfew();
    private void RemoveFlag_DisobeyingCurfew();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002EVision_002EPlayerVisibility_Assembly_002DCSharp_002Edll();
}