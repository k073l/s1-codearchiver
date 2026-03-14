using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;

namespace ScheduleOne.NPCs.Behaviour;
public class ApplySpawnToMushroomBedBehaviour : GrowContainerBehaviour
{
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EApplySpawnToMushroomBedBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EApplySpawnToMushroomBedBehaviourAssembly_002DCSharp_002Edll_Excuted;
    protected override float GetActionDuration();
    protected override string GetAnimationBool();
    protected override string[] GetRequiredItemSuitableIDs(GrowContainer growContainer);
    protected override void OnActionSuccess(ItemInstance usedItem);
    public override bool AreTaskConditionsMetForContainer(GrowContainer container);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}