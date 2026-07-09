using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.ItemFramework;
using ScheduleOne.Law;
using ScheduleOne.Map;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.Product.Packaging;
using ScheduleOne.State;
using ScheduleOne.Vehicles;
using TMPro;
using UnityEngine;

namespace ScheduleOne.UI;
public class ArrestNoticeScreen : Singleton<ArrestNoticeScreen>
{
    public const float VEHICLE_POSSESSION_TIMEOUT;
    [Header("References")]
    public Canvas Canvas;
    public CanvasGroup CanvasGroup;
    public RectTransform CrimeEntryContainer;
    public RectTransform PenaltyEntryContainer;
    public MonoState State;
    [Header("Prefabs")]
    public RectTransform CrimeEntryPrefab;
    public RectTransform PenaltyEntryPrefab;
    private Dictionary<Crime, int> recordedCrimes;
    private LandVehicle vehicle;
    public bool isOpen { get; protected set; }

    protected override void Awake();
    private void PlayerSpawned();
    public void Exit();
    public void Open();
    private void OnClose();
    public void RecordCrimes();
    private void RecordPossession(EStealthLevel maxStealthLevel);
    private void ConfiscateItems(EStealthLevel maxStealthLevel);
    private void ClearEntries();
}