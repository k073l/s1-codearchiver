using System;
using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.Money;
using ScheduleOne.PlayerScripts;
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
    private bool arrested;
    public bool isOpen { get; protected set; }

    protected override void Awake();
    private void Exit(ExitAction action);
    private void PlayerSpawned();
    public void Open();
    public void Close();
}