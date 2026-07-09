using System;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using UnityEngine;

namespace ScheduleOne.Casino;
public abstract class CasinoGameController : NetworkBehaviour
{
    public const float FOV;
    public const float CAMERA_LERP_TIME;
    [Header("References")]
    public CasinoGamePlayers Players;
    public CasinoGameInteraction Interaction;
    public Transform[] DefaultCameraTransforms;
    public MonoState State;
    public Action onLocalPlayerBetChange;
    protected Transform localDefaultCameraTransform;
    private bool NetworkInitialize___EarlyScheduleOne_002ECasino_002ECasinoGameControllerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ECasino_002ECasinoGameControllerAssembly_002DCSharp_002Edll_Excuted;
    public bool IsOpen { get; private set; }
    public float LocalPlayerBet { get; protected set; }
    public CasinoGamePlayerData LocalPlayerData => Players.GetPlayerData();

    public override void Awake();
    protected virtual void OnLocalPlayerRequestJoin(Player player);
    protected virtual void Exit(ExitAction action);
    protected virtual void Open();
    protected void Close();
    protected virtual void OnClose();
    public void SetLocalPlayerBet(float bet);
    public virtual void ToggleLocalPlayerReady();
    public abstract bool IsWaitingForPlayers();
    public abstract void GetBetLimits(out float minimum, out float maximum);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected virtual void Awake_UserLogic_ScheduleOne_002ECasino_002ECasinoGameController_Assembly_002DCSharp_002Edll();
}