using System;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.Economy;
using ScheduleOne.Messaging;
using ScheduleOne.NPCs.Relation;
using ScheduleOne.UI.Phone.Messages;
using ScheduleOne.Variables;

namespace ScheduleOne.NPCs.CharacterClasses;
public class Phil : Supplier
{
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ECharacterClasses_002EPhilAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ECharacterClasses_002EPhilAssembly_002DCSharp_002Edll_Excuted;
    protected override void CreateMessageConversation();
    protected virtual void InstructionsRequested();
    protected override void SupplierUnlocked(NPCRelationData.EUnlockType type, bool notify);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}