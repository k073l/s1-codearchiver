using System.Collections.Generic;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Variables;
using UnityEngine;

namespace ScheduleOne.Property;
public class MotelRoom : Property
{
    private List<Pot> pots;
    private List<PackagingStation> packagingStations;
    private List<MixingStation> mixingStations;
    private bool NetworkInitialize___EarlyScheduleOne_002EProperty_002EMotelRoomAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EProperty_002EMotelRoomAssembly_002DCSharp_002Edll_Excuted;
    protected override void Start();
    private void UpdateVariables();
    public override bool CanDeliverToProperty();
    private void BuildableItemRemoved(BuildableItem item);
    private void BuildableItemAdded(BuildableItem item);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}