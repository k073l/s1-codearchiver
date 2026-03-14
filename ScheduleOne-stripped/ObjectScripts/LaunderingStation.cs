using System;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Property;
using ScheduleOne.Tiles;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.ObjectScripts;
public class LaunderingStation : GridItem
{
    [Header("References")]
    public LaunderingInterface Interface;
    [SerializeField]
    protected CashCounter CashCounter;
    private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002ELaunderingStationAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002ELaunderingStationAssembly_002DCSharp_002Edll_Excuted;
    public override void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID);
    private void OnDestroy();
    private void OnStartOperation(LaunderingOperation operation);
    private void OnFinishOperation(LaunderingOperation operation);
    private void UpdateCashCounter();
    public override bool CanBeDestroyed(out string reason);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}