using FishNet;
using FishNet.Object;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Property;
using UnityEngine;

namespace ScheduleOne.NPCs.CharacterClasses;
public class SewerKing : NPC
{
    public SewerOffice sewerOffice;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ECharacterClasses_002ESewerKingAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ECharacterClasses_002ESewerKingAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    protected override void MinPass();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002ENPCs_002ECharacterClasses_002ESewerKing_Assembly_002DCSharp_002Edll();
}