using System;
using System.Collections;
using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Audio;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.Core.Networking;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class ConsumeProductBehaviour : Behaviour
{
    [Header("Equippables")]
    public AvatarEquippable JointPrefab;
    public AvatarEquippable PipePrefab;
    public AvatarEquippable ShroomPrefab;
    [Header("References")]
    public AudioSourceController WeedConsumeSound;
    public AudioSourceController MethConsumeSound;
    public AudioSourceController SnortSound;
    public AudioSourceController EatSound;
    public ParticleSystem SmokeExhaleParticles;
    private ProductItemInstance _appliedProduct;
    [ServerOnly]
    private ProductItemInstance _productToConsume;
    [ServerOnly]
    private bool _removeFromInventoryOnConsume;
    private Coroutine _consumeRoutine;
    private TimedCallback _effectsCooldownTimer;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EConsumeProductBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EConsumeProductBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public bool IsAnyProductActive => _appliedProduct != null;

    public event Action<ProductItemInstance> OnProductConsumed;
    protected virtual void Start();
    private void OnDestroy();
    public override void OnStartServer();
    private void OnNPCDeinitialize();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SetProduct_Server(ProductItemInstance product, bool removeFromInventory);
    protected override void OnActivateOrResume();
    protected override void OnDeactivateOrPause();
    [ObserversRpc]
    private void ConsumeProduct_Client(ProductItemInstance product);
    private IEnumerator PlayWeedAnimation();
    private IEnumerator PlayMethAnimation();
    private IEnumerator PlayCocaineAnimation();
    private IEnumerator PlayShroomsAnimation();
    [ObserversRpc]
    private void ApplyEffects_Client(ProductItemInstance product);
    [ObserversRpc(RunLocally = true)]
    private void ClearEffects_Client();
    private void DayPass();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SetProduct_Server_3964170259(ProductItemInstance product, bool removeFromInventory);
    public void RpcLogic___SetProduct_Server_3964170259(ProductItemInstance product, bool removeFromInventory);
    private void RpcReader___Server_SetProduct_Server_3964170259(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_ConsumeProduct_Client_2622925554(ProductItemInstance product);
    private void RpcLogic___ConsumeProduct_Client_2622925554(ProductItemInstance product);
    private void RpcReader___Observers_ConsumeProduct_Client_2622925554(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ApplyEffects_Client_2622925554(ProductItemInstance product);
    private void RpcLogic___ApplyEffects_Client_2622925554(ProductItemInstance product);
    private void RpcReader___Observers_ApplyEffects_Client_2622925554(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ClearEffects_Client_2166136261();
    private void RpcLogic___ClearEffects_Client_2166136261();
    private void RpcReader___Observers_ClearEffects_Client_2166136261(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}