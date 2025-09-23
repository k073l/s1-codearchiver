using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.Map;
using ScheduleOne.Persistence;
using ScheduleOne.Variables;
using ScheduleOne.Vehicles;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.NPCs.CharacterClasses;
public class Jeremy : NPC
{
    [Serializable]
    public class DealershipListing
    {
        public string vehicleCode;
        public string vehicleName => NetworkSingleton<VehicleManager>.Instance.GetVehiclePrefab(vehicleCode).VehicleName;
        public float price => NetworkSingleton<VehicleManager>.Instance.GetVehiclePrefab(vehicleCode).VehiclePrice;
    }

    public Dealership Dealership;
    public List<DealershipListing> Listings;
    public DialogueContainer GreetingDialogue;
    public string GreetedVariable;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002ECharacterClasses_002EJeremyAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002ECharacterClasses_002EJeremyAssembly_002DCSharp_002Edll_Excuted;
    protected override void Start();
    private void Loaded();
    private void EnableGreeting();
    private void SetGreeted();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}