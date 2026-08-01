using ScheduleOne.DevUtilities;
using ScheduleOne.Map;
using ScheduleOne.NPCs.Schedules;
using UnityEngine;

namespace ScheduleOne.NPCs.CharacterClasses;
public class Igor : NPC
{
    public NPCEvent DoorGuardEvent;
    public NPCEvent OfficeGuardEvent;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ECharacterClasses_002EIgorAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ECharacterClasses_002EIgorAssembly_002DCSharp_002Edll_Excuted;
    protected override void Start();
    private void GuardDoor();
    private void GuardOffice();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}