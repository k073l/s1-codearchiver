using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.Persistence;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs.CharacterClasses;
public class Fixer : NPC
{
    public const int ADDITIONAL_SIGNING_FEE_1;
    public const int ADDITIONAL_SIGNING_FEE_2;
    public const int MAX_SIGNING_FEE;
    public const int ADDITIONAL_FEE_THRESHOLD;
    public DialogueContainer GreetingDialogue;
    public string GreetedVariable;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ECharacterClasses_002EFixerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ECharacterClasses_002EFixerAssembly_002DCSharp_002Edll_Excuted;
    protected override void Start();
    private void Loaded();
    private void EnableGreeting();
    private void SetGreeted();
    public static float GetAdditionalSigningFee();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}