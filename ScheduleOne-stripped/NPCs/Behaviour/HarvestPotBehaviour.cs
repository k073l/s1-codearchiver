using System.Collections.Generic;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class HarvestPotBehaviour : GrowContainerBehaviour
{
    public AvatarEquippable TrimmersEquippable;
    private Pot _pot;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EHarvestPotBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EHarvestPotBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    public override void AssignAndEnable(GrowContainer growContainer);
    protected override float GetActionDuration();
    protected override string GetAnimationBool();
    protected override AvatarEquippable GetActionEquippable();
    protected override void OnActionSuccess(ItemInstance usedItem);
    private int GetQuantityToHarvest();
    public override bool AreTaskConditionsMetForContainer(GrowContainer container);
    protected override bool CheckSuccess(ItemInstance usedItem);
    public bool DoesPotHaveValidDestination(Pot pot);
    private int GetDestinationCapacityForItem(Pot pot, ItemInstance item);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EHarvestPotBehaviour_Assembly_002DCSharp_002Edll();
}