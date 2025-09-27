using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.Money;
using ScheduleOne.ObjectScripts.Cash;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
public class CashPickup : ItemPickup
{
    [SyncVar(OnChange = "ValueChanged")]
    public float Value;
    public bool PlayCashPickupSound;
    [Header("References")]
    public CashStackVisuals CashStackVisuals;
    public SyncVar<float> syncVar___Value;
    private bool NetworkInitialize___EarlyScheduleOne_002EItemFramework_002ECashPickupAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EItemFramework_002ECashPickupAssembly_002DCSharp_002Edll_Excuted;
    public float SyncAccessor_Value { get; set; }

    private void Start();
    protected override void Hovered();
    protected override bool CanPickup();
    protected override void Pickup();
    private void ValueChanged(float oldValue, float newValue, bool asServer);
    private void UpdateCashStackVisuals();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override bool ReadSyncVar___ScheduleOne_002EItemFramework_002ECashPickup(PooledReader PooledReader0, uint UInt321, bool Boolean2);
    public override void Awake();
}