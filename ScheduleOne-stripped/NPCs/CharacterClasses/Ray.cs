using System;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.Levelling;
using ScheduleOne.Persistence;
using ScheduleOne.Property;
using ScheduleOne.UI.Phone.Messages;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs.CharacterClasses;
public class Ray : NPC
{
    public DialogueContainer GreetingDialogue;
    public string GreetedVariable;
    public string IntroductionMessage;
    public string IntroSentVariable;
    [Header("Intro message conditions")]
    public FullRank IntroRank;
    public int IntroDaysPlayed;
    public float IntroNetworth;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ECharacterClasses_002ERayAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ECharacterClasses_002ERayAssembly_002DCSharp_002Edll_Excuted;
    protected override void Start();
    private void Loaded();
    private void EnableGreeting();
    private void SetGreeted();
    private void NotifyPlayerOfManorRebuild();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}