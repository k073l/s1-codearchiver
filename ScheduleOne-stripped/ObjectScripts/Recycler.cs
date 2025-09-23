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
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Interaction;
using ScheduleOne.Misc;
using ScheduleOne.Money;
using ScheduleOne.Trash;
using ScheduleOne.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.ObjectScripts;
public class Recycler : NetworkBehaviour
{
    public enum EState
    {
        HatchClosed,
        HatchOpen,
        Processing
    }

    public LayerMask DetectionMask;
    [Header("References")]
    public InteractableObject HandleIntObj;
    public InteractableObject ButtonIntObj;
    public InteractableObject CashIntObj;
    public ToggleableLight ButtonLight;
    public Animation ButtonAnim;
    public Animation HatchAnim;
    public Animation CashAnim;
    public RectTransform OpenHatchInstruction;
    public RectTransform InsertTrashInstruction;
    public RectTransform PressBeginInstruction;
    public RectTransform ProcessingScreen;
    public TextMeshProUGUI ProcessingLabel;
    public TextMeshProUGUI ValueLabel;
    public BoxCollider CheckCollider;
    public Transform Cash;
    public GameObject BankNote;
    [Header("Sound")]
    public AudioSourceController OpenSound;
    public AudioSourceController CloseSound;
    public AudioSourceController PressSound;
    public AudioSourceController DoneSound;
    public AudioSourceController CashEjectSound;
    private float cashValue;
    public UnityEvent onStart;
    public UnityEvent onStop;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002ERecyclerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002ERecyclerAssembly_002DCSharp_002Edll_Excuted;
    public EState State { get; protected set; }
    public bool IsHatchOpen { get; private set; }

    public void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    private void OnDestroy();
    private void MinPass();
    public void HandleInteracted();
    public void ButtonInteracted();
    public void CashInteracted();
    [ServerRpc(RequireOwnership = false)]
    private void SendCashCollected();
    [ObserversRpc(RunLocally = true)]
    private void CashCollected();
    [ObserversRpc(RunLocally = true)]
    private void EnableCash();
    [ObserversRpc(RunLocally = true)]
    private void SetCashValue(float amount);
    private IEnumerator Process(bool startedByLocalPlayer);
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendState(EState state);
    [ObserversRpc(RunLocally = true)]
    [TargetRpc]
    private void SetState(NetworkConnection conn, EState state, bool force = false);
    private void SetHatchOpen(bool open);
    private TrashItem[] GetTrash();
    private void OnDrawGizmos();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SendCashCollected_2166136261();
    private void RpcLogic___SendCashCollected_2166136261();
    private void RpcReader___Server_SendCashCollected_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_CashCollected_2166136261();
    private void RpcLogic___CashCollected_2166136261();
    private void RpcReader___Observers_CashCollected_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_EnableCash_2166136261();
    private void RpcLogic___EnableCash_2166136261();
    private void RpcReader___Observers_EnableCash_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_SetCashValue_431000436(float amount);
    private void RpcLogic___SetCashValue_431000436(float amount);
    private void RpcReader___Observers_SetCashValue_431000436(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Server_SendState_3569965459(EState state);
    public void RpcLogic___SendState_3569965459(EState state);
    private void RpcReader___Server_SendState_3569965459(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetState_3790170803(NetworkConnection conn, EState state, bool force = false);
    private void RpcLogic___SetState_3790170803(NetworkConnection conn, EState state, bool force = false);
    private void RpcReader___Observers_SetState_3790170803(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Target_SetState_3790170803(NetworkConnection conn, EState state, bool force = false);
    private void RpcReader___Target_SetState_3790170803(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}