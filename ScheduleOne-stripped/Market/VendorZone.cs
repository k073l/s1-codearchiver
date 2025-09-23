using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Market;
public class VendorZone : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    protected BoxCollider zoneCollider;
    [SerializeField]
    protected List<GameObject> doors;
    [Header("Settings")]
    [SerializeField]
    protected int openTime;
    [SerializeField]
    protected int closeTime;
    public bool isOpen => NetworkSingleton<TimeManager>.Instance.IsCurrentTimeWithinRange(openTime, closeTime);

    protected virtual void Start();
    private void MinPassed();
    private bool IsPlayerWithinVendorZone();
    private void SetDoorsActive(bool a);
}