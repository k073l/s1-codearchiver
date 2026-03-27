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
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.Product;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs.Behaviour;
public class ConsumeProductBehaviour : Behaviour
{
    public AvatarEquippable JointPrefab;
    public AvatarEquippable PipePrefab;
    public AvatarEquippable ShroomPrefab;
    private ProductItemInstance product;
    private Coroutine consumeRoutine;
    public AudioSourceController WeedConsumeSound;
    public AudioSourceController MethConsumeSound;
    public AudioSourceController SnortSound;
    public AudioSourceController EatSound;
    public ParticleSystem SmokeExhaleParticles;
    public UnityEvent onConsumeDone;
    private TimedCallback _effectsCooldownTimer;
    private bool _removeFromInventoryOnConsume;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EConsumeProductBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EConsumeProductBehaviourAssembly_002DCSharp_002Edll_Excuted;
    public ProductItemInstance ConsumedProduct { get; private set; }

    protected virtual void Start();
    [ServerRpc(RequireOwnership = false, RunLocally = true)]
    public void SendProduct(ProductItemInstance _product, bool removeFromInventory);
    [ObserversRpc(RunLocally = true)]
    private void SetProduct(ProductItemInstance _product, bool removeFromInventory);
    [ObserversRpc(RunLocally = true)]
    public void ClearEffects();
    public override void Activate();
    public override void Resume();
    private void TryConsume();
    public override void Disable();
    public override void Deactivate();
    private void ConsumeWeed();
    private void ConsumeMeth();
    private void ConsumeCocaine();
    private void ConsumeShrooms();
    [ObserversRpc(RunLocally = true)]
    private void ApplyEffects();
    private void Clear();
    private void DayPass();
    private void ConsumeDone();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Server_SendProduct_3964170259(ProductItemInstance _product, bool removeFromInventory);
    public void RpcLogic___SendProduct_3964170259(ProductItemInstance _product, bool removeFromInventory);
    private void RpcReader___Server_SendProduct_3964170259(PooledReader PooledReader0, Channel channel, NetworkConnection conn);
    private void RpcWriter___Observers_SetProduct_3964170259(ProductItemInstance _product, bool removeFromInventory);
    private void RpcLogic___SetProduct_3964170259(ProductItemInstance _product, bool removeFromInventory);
    private void RpcReader___Observers_SetProduct_3964170259(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ClearEffects_2166136261();
    public void RpcLogic___ClearEffects_2166136261();
    private void RpcReader___Observers_ClearEffects_2166136261(PooledReader PooledReader0, Channel channel);
    private void RpcWriter___Observers_ApplyEffects_2166136261();
    private void RpcLogic___ApplyEffects_2166136261();
    private void RpcReader___Observers_ApplyEffects_2166136261(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}