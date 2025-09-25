using EasyButtons;
using FishNet;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Audio;
using UnityEngine;

namespace ScheduleOne.Map;
public class Gate : NetworkBehaviour
{
    public Transform Gate1;
    public Vector3 Gate1Open;
    public Vector3 Gate1Closed;
    public Transform Gate2;
    public Vector3 Gate2Open;
    public Vector3 Gate2Closed;
    public float OpenSpeed;
    public float Acceleration;
    [Header("Sound")]
    public AudioSourceController[] StartSounds;
    public AudioSourceController[] LoopSounds;
    public AudioSourceController[] StopSounds;
    private float Momentum;
    private float openDelta;
    private bool NetworkInitialize___EarlyScheduleOne_002EMap_002EGateAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EMap_002EGateAssembly_002DCSharp_002Edll_Excuted;
    public bool IsOpen { get; protected set; }

    private void Update();
    [Button]
    [ObserversRpc(RunLocally = true)]
    public void Open();
    [Button]
    [ObserversRpc]
    public void Close();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_Open_2166136261();
    public void RpcLogic___Open_2166136261();
    private void RpcReader___Observers_Open_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_Close_2166136261();
    public void RpcLogic___Close_2166136261();
    private void RpcReader___Observers_Close_2166136261(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}