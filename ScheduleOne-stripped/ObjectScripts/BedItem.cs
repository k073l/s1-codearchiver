using ScheduleOne.EntityFramework;
using ScheduleOne.Money;
using ScheduleOne.Storage;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.ObjectScripts;
public class BedItem : PlaceableStorageEntity
{
    public Bed Bed;
    public StorageEntity Storage;
    public GameObject Briefcase;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002EBedItemAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002EBedItemAssembly_002DCSharp_002Edll_Excuted;
    protected override void Start();
    public static bool IsBedValid(BuildableItem obj, out string reason);
    private void UpdateBriefcase();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}