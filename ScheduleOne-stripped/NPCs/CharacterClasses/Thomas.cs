using System;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Cartel;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.Messaging;
using ScheduleOne.UI.Phone.Messages;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs.CharacterClasses;
public class Thomas : NPC
{
    public Sprite MessagingIcon;
    public UnityEvent onMeetingEnded;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ECharacterClasses_002EThomasAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ECharacterClasses_002EThomasAssembly_002DCSharp_002Edll_Excuted;
    public override Sprite GetMessagingIcon();
    public void SendIntroMessage();
    [ServerRpc(RequireOwnership = false)]
    public void MeetingEnded_Server();
    [ObserversRpc]
    private void MeetingEnded();
    protected override void CreateMessageConversation();
    [ServerRpc(RequireOwnership = false)]
    private void CancelAgreement_Server();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_MeetingEnded_Server_2166136261();
    public void RpcLogic___MeetingEnded_Server_2166136261();
    private void RpcReader___Server_MeetingEnded_Server_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_MeetingEnded_2166136261();
    private void RpcLogic___MeetingEnded_2166136261();
    private void RpcReader___Observers_MeetingEnded_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_CancelAgreement_Server_2166136261();
    private void RpcLogic___CancelAgreement_Server_2166136261();
    private void RpcReader___Server_CancelAgreement_Server_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    public override void Awake();
}