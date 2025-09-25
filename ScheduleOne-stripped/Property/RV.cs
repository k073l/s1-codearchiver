using System;
using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.GameTime;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Product;
using ScheduleOne.Storage;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Property;
public class RV : Property
{
    public Transform ModelContainer;
    public Transform FXContainer;
    public UnityEvent onSetExploded;
    private bool NetworkInitialize___EarlyScheduleOne_002EProperty_002ERVAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EProperty_002ERVAssembly_002DCSharp_002Edll_Excuted;
    public bool _isExploded { get; private set; }

    protected override void Start();
    public override void OnSpawnServer(NetworkConnection connection);
    private void UpdateVariables();
    public void Ransack();
    public override bool ShouldSave();
    [TargetRpc]
    public void SetExploded(NetworkConnection conn);
    public void SetExploded();
    private void OnSleep();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Target_SetExploded_328543758(NetworkConnection conn);
    public void RpcLogic___SetExploded_328543758(NetworkConnection conn);
    private void RpcReader___Target_SetExploded_328543758(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}