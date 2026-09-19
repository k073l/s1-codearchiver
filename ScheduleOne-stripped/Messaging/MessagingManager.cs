using System;
using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.Networking;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.Phone.Messages;
using UnityEngine;

namespace ScheduleOne.Messaging;
public class MessagingManager : NetworkSingleton<MessagingManager>
{
    protected Dictionary<string, MSGConversation> _senderIdConversationMap;
    private bool NetworkInitialize___EarlyScheduleOne_002EMessaging_002EMessagingManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EMessaging_002EMessagingManagerAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    public override void OnSpawnServer(NetworkConnection connection);
    public void Register(MSGConversation conversation);
    public bool TryGetConversation(string senderId, out MSGConversation conversation);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendMessage_Server(Message m, bool notify, string id);
    [ObserversRpc(RunLocally = true)]
    private void SendMessage_Client(Message m, bool notify, string id);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendMessageChain_Server(MessageChain m, string id, float initialDelay, bool notify);
    [ObserversRpc(RunLocally = true)]
    private void SendMessageChain_Client(MessageChain m, string id, float initialDelay, bool notify);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendResponse_Server(int responseIndex, string id);
    [ObserversRpc(RunLocally = true)]
    private void SendResponse_Client(int responseIndex, string id);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendPlayerMessage_Server(int sendableIndex, int sentIndex, string id);
    [ObserversRpc(RunLocally = true)]
    private void SendPlayerMessage_Client(int sendableIndex, int sentIndex, string id);
    [ServerRpc(RequireOwnership = false)]
    public void ClearResponses_Server(string id);
    [ObserversRpc]
    private void ClearResponses_Client(string id);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void ShowResponses_Server(string id, List<Response> responses, float delay);
    [ObserversRpc(RunLocally = true)]
    private void ShowResponses_Client(string id, List<Response> responses, float delay);
    [TargetRpc]
    private void ReceiveMSGConversationData(NetworkConnection conn, string id, MSGConversationData data);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SendMessage_Server_2134336246(Message m, bool notify, string id);
    public void RpcLogic___SendMessage_Server_2134336246(Message m, bool notify, string id);
    private void RpcReader___Server_SendMessage_Server_2134336246(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SendMessage_Client_2134336246(Message m, bool notify, string id);
    private void RpcLogic___SendMessage_Client_2134336246(Message m, bool notify, string id);
    private void RpcReader___Observers_SendMessage_Client_2134336246(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendMessageChain_Server_3949292778(MessageChain m, string id, float initialDelay, bool notify);
    public void RpcLogic___SendMessageChain_Server_3949292778(MessageChain m, string id, float initialDelay, bool notify);
    private void RpcReader___Server_SendMessageChain_Server_3949292778(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SendMessageChain_Client_3949292778(MessageChain m, string id, float initialDelay, bool notify);
    private void RpcLogic___SendMessageChain_Client_3949292778(MessageChain m, string id, float initialDelay, bool notify);
    private void RpcReader___Observers_SendMessageChain_Client_3949292778(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendResponse_Server_2801973956(int responseIndex, string id);
    public void RpcLogic___SendResponse_Server_2801973956(int responseIndex, string id);
    private void RpcReader___Server_SendResponse_Server_2801973956(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SendResponse_Client_2801973956(int responseIndex, string id);
    private void RpcLogic___SendResponse_Client_2801973956(int responseIndex, string id);
    private void RpcReader___Observers_SendResponse_Client_2801973956(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendPlayerMessage_Server_1952281135(int sendableIndex, int sentIndex, string id);
    public void RpcLogic___SendPlayerMessage_Server_1952281135(int sendableIndex, int sentIndex, string id);
    private void RpcReader___Server_SendPlayerMessage_Server_1952281135(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SendPlayerMessage_Client_1952281135(int sendableIndex, int sentIndex, string id);
    private void RpcLogic___SendPlayerMessage_Client_1952281135(int sendableIndex, int sentIndex, string id);
    private void RpcReader___Observers_SendPlayerMessage_Client_1952281135(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ClearResponses_Server_3615296227(string id);
    public void RpcLogic___ClearResponses_Server_3615296227(string id);
    private void RpcReader___Server_ClearResponses_Server_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ClearResponses_Client_3615296227(string id);
    private void RpcLogic___ClearResponses_Client_3615296227(string id);
    private void RpcReader___Observers_ClearResponses_Client_3615296227(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_ShowResponses_Server_995803534(string id, List<Response> responses, float delay);
    public void RpcLogic___ShowResponses_Server_995803534(string id, List<Response> responses, float delay);
    private void RpcReader___Server_ShowResponses_Server_995803534(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ShowResponses_Client_995803534(string id, List<Response> responses, float delay);
    private void RpcLogic___ShowResponses_Client_995803534(string id, List<Response> responses, float delay);
    private void RpcReader___Observers_ShowResponses_Client_995803534(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_ReceiveMSGConversationData_2662241369(NetworkConnection conn, string id, MSGConversationData data);
    private void RpcLogic___ReceiveMSGConversationData_2662241369(NetworkConnection conn, string id, MSGConversationData data);
    private void RpcReader___Target_ReceiveMSGConversationData_2662241369(PooledReader PooledReader0, Channel channel);
    protected override void Awake_UserLogic_ScheduleOne_002EMessaging_002EMessagingManager_Assembly_002DCSharp_002Edll();
}