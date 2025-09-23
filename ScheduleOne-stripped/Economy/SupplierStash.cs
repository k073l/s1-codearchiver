using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Map;
using ScheduleOne.Money;
using ScheduleOne.NPCs.Relation;
using ScheduleOne.Storage;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Economy;
public class SupplierStash : MonoBehaviour
{
    public string locationDescription;
    [Header("References")]
    public Supplier Supplier;
    public StorageEntity Storage;
    public InteractableObject IntObj;
    public OptimizedLight Light;
    public POI StashPoI;
    public float CashAmount { get; private set; }

    protected virtual void Awake();
    protected virtual void Start();
    private void SupplierUnlocked();
    private void RecalculateCash();
    private void Interacted();
    public void RemoveCash(float amount);
    private void UpdateDeadDrop();
}