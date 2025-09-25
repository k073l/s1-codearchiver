using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.Persistence;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.Variables;
using ScheduleOne.Vehicles;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs.CharacterClasses;
public class Marco : NPC
{
    public Transform VehicleRecoveryPoint;
    public VehicleDetector VehicleDetector;
    public DialogueContainer RecoveryConversation;
    public DialogueContainer GreetingDialogue;
    public string GreetedVariable;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ECharacterClasses_002EMarcoAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ECharacterClasses_002EMarcoAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    protected override void Start();
    private bool ShouldShowRecoverVehicle(bool enabled);
    private bool RecoverVehicleValid(out string reason);
    private bool RepaintVehicleValid(out string reason);
    private void RecoverVehicle();
    private void Loaded();
    private void EnableGreeting();
    private void SetGreeted();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002ECharacterClasses_002EMarco_Assembly_002DCSharp_002Edll();
}