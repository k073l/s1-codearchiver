using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Money;
using ScheduleOne.Property;
using ScheduleOne.Property.Utilities.Power;
using ScheduleOne.Property.Utilities.Water;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone;
public class UtilitiesApp : App<UtilitiesApp>
{
    [Header("References")]
    [SerializeField]
    protected Text water_Usage;
    [SerializeField]
    protected Text water_Cost;
    [SerializeField]
    protected Text water_Total;
    [SerializeField]
    protected Text electricity_Usage;
    [SerializeField]
    protected Text electricity_Cost;
    [SerializeField]
    protected Text electricity_Total;
    [SerializeField]
    protected Text dumpster_Count;
    [SerializeField]
    protected Text dumpster_EmptyCost;
    [SerializeField]
    protected Text dumpster_Total;
    [SerializeField]
    protected Button dumpsterButton;
    [SerializeField]
    protected PropertyDropdown propertySelector;
    private ScheduleOne.Property.Property selectedProperty;
    protected override void Awake();
    protected override void OnDestroy();
    protected override void Update();
    protected virtual void RefreshShownValues();
    protected virtual void OnDayPass();
    private float Round(float n, float decimals);
    public override void SetOpen(bool open);
}