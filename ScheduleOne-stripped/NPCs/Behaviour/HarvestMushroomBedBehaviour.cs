using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class HarvestMushroomBedBehaviour : GrowContainerBehaviour
{
    public AvatarEquippable TrimmersEquippable;
    private MushroomBed _bed;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EHarvestMushroomBedBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EHarvestMushroomBedBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    public override void AssignAndEnable(GrowContainer growContainer);
    protected override float GetActionDuration();
    protected override string GetAnimationBool();
    protected override AvatarEquippable GetActionEquippable();
    protected override void OnActionSuccess(ItemInstance usedItem);
    private int GetQuantityToHarvest();
    public override bool AreTaskConditionsMetForContainer(GrowContainer container);
    protected override bool CheckSuccess(ItemInstance usedItem);
    public bool DoesMushroomBedHaveValidDestination(MushroomBed bed);
    private int GetDestinationCapacityForItem(MushroomBed bed, ItemInstance item);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002EBehaviour_002EHarvestMushroomBedBehaviour_Assembly_002DCSharp_002Edll();
}