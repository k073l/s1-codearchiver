using System.Collections.Generic;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Variables;
using UnityEngine;

namespace ScheduleOne.Property;
public class Sweatshop : Property
{
    private List<Pot> pots;
    private List<PackagingStation> packagingStations;
    private List<MixingStation> mixingStations;
    private bool NetworkInitialize___EarlyScheduleOne_002EProperty_002ESweatshopAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EProperty_002ESweatshopAssembly_002DCSharp_002Edll_Excuted;
    protected override void Start();
    private void UpdateVariables();
    private void BuildableItemRemoved(BuildableItem item);
    private void BuildableItemAdded(BuildableItem item);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}