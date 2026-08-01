using System;
using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.Money;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using TMPro;
using UnityEngine;

namespace ScheduleOne.UI;
public class HospitalBillScreen : Singleton<HospitalBillScreen>
{
    public const float BILL_COST;
    [Header("References")]
    public Canvas Canvas;
    public RectTransform Container;
    public CanvasGroup CanvasGroup;
    public TextMeshProUGUI PatientNameLabel;
    public TextMeshProUGUI BillNumberLabel;
    public TextMeshProUGUI PaidAmountLabel;
    public MonoState State;
    private bool arrested;
    public bool isOpen { get; protected set; }

    protected override void Awake();
    private void Exit(ExitAction action);
    private void PlayerSpawned();
    public void Open();
    public void Close();
    public void OnClose();
}