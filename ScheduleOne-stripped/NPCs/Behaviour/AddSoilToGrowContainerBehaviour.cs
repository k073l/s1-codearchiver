using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Equipping;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts.Soil;
using ScheduleOne.Trash;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class AddSoilToGrowContainerBehaviour : GrowContainerBehaviour
{
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EAddSoilToGrowContainerBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EAddSoilToGrowContainerBehaviourAssembly_002DCSharp_002Edll_Excuted;
    protected override float GetActionDuration();
    protected override string GetAnimationBool();
    protected override AvatarEquippable GetActionEquippable();
    protected override string[] GetRequiredItemSuitableIDs(GrowContainer growContainer);
    protected override void OnActionSuccess(ItemInstance usedItem);
    public override bool AreTaskConditionsMetForContainer(GrowContainer container);
    protected override TrashItem GetTrashPrefab(ItemInstance usedItem);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}