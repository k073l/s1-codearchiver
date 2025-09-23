using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.Persistence;
using ScheduleOne.UI.Shop;
using ScheduleOne.Variables;
using ScheduleOne.VoiceOver;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs;
public class Stan : NPC
{
    public ShopInterface ShopInterface;
    public DialogueContainer GreetingDialogue;
    public string GreetedVariable;
    [Header("Settings")]
    public string[] OrderCompletedLines;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EStanAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EStanAssembly_002DCSharp_002Edll_Excuted;
    protected override void Start();
    private void Loaded();
    private void EnableGreeting();
    private void SetGreeted();
    private void OrderCompleted();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}