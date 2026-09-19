using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace ScheduleOne.MiniGames;
public class BeerPong : NetworkBehaviour
{
    private const float CupStackOffset;
    private const float StackCupDelay;
    [Header("Components")]
    [SerializeField]
    private List<BeerPongCup> _cups;
    [SerializeField]
    private Transform _cupStackPosition;
    [SerializeField]
    private GameObject _resetCupsInteraction;
    private List<BeerPongCup> _stackedCups;
    private bool NetworkInitialize___EarlyScheduleOne_002EMiniGames_002EBeerPongAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EMiniGames_002EBeerPongAssembly_002DCSharp_002Edll_Excuted;
    public override void Awake();
    public override void OnStartServer();
    public override void OnSpawnServer(NetworkConnection connection);
    public void ResetCups();
    [ServerRpc(RequireOwnership = false)]
    private void ResetCups_Server();
    [Server]
    private void OnBallEnteredCup(BeerPongCup cup, TableTennisBall ball);
    [ObserversRpc]
    [TargetRpc]
    private void SetCupStacked(NetworkConnection conn, int cupIndex, bool stacked);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_ResetCups_Server_2166136261();
    private void RpcLogic___ResetCups_Server_2166136261();
    private void RpcReader___Server_ResetCups_Server_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetCupStacked_338960014(NetworkConnection conn, int cupIndex, bool stacked);
    private void RpcLogic___SetCupStacked_338960014(NetworkConnection conn, int cupIndex, bool stacked);
    private void RpcReader___Observers_SetCupStacked_338960014(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetCupStacked_338960014(NetworkConnection conn, int cupIndex, bool stacked);
    private void RpcReader___Target_SetCupStacked_338960014(PooledReader PooledReader0, Channel channel);
    private void Awake_UserLogic_ScheduleOne_002EMiniGames_002EBeerPong_Assembly_002DCSharp_002Edll();
}