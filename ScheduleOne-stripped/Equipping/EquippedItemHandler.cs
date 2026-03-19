using System;
using FishNet.Component.Ownership;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.Equipping;
[RequireComponent(typeof(PredictedSpawn))]
public class EquippedItemHandler : NetworkBehaviour, IEquippedItemHandler
{
    [SyncVar]
    public INetworkedEquippableUser _user;
    [SyncVar]
    [HideInInspector]
    public EquippableData _equippableData;
    public SyncVar<INetworkedEquippableUser> syncVar____user;
    public SyncVar<EquippableData> syncVar____equippableData;
    private bool NetworkInitialize___EarlyScheduleOne_002EEquipping_002EEquippedItemHandlerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EEquipping_002EEquippedItemHandlerAssembly_002DCSharp_002Edll_Excuted;
    public IEquippableUser User => SyncAccessor__user;
    public EquippableData EquippableData => SyncAccessor__equippableData;
    public bool IsEquipped { get; private set; }
    public INetworkedEquippableUser SyncAccessor__user { get; set; }
    public EquippableData SyncAccessor__equippableData { get; set; }

    public event Action OnUnequipped;
    public virtual void Equipped(IEquippableUser user, EquippableData data);
    public virtual void EquippedWithItem(IEquippableUser user, EquippableData data, BaseItemInstance itemInstance);
    public virtual void Unequipped();
    public override void OnStartClient();
    private void SetupParent();
    protected virtual void SetupThirdPerson();
    protected virtual void SetupFirstPerson();
    protected virtual void Update();
    protected virtual void UserUpdate();
    GameObject IEquippedItemHandler.get_gameObject();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override bool ReadSyncVar___ScheduleOne_002EEquipping_002EEquippedItemHandler(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    public override void Awake();
}