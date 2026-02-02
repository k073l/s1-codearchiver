using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;

namespace ScheduleOne.Map;
public class ScheduledMaterialChange : MonoBehaviour
{
    private enum EOnState
    {
        Undecided,
        On,
        Off
    }

    public MeshRenderer[] Renderers;
    public int MaterialIndex;
    [Header("Settings")]
    public bool Enabled;
    public bool LogState;
    public Material OutsideTimeRangeMaterial;
    public Material InsideTimeRangeMaterial;
    public int TimeRangeMin;
    public int TimeRangeMax;
    public int TimeRangeShift;
    public int TimeRangeRandomization;
    [Range(0f, 1f)]
    public float TurnOnChance;
    [Range(0f, 1f)]
    public float TurnOffChance;
    private bool appliedInsideTimeRange;
    private EOnState onState;
    private int randomShift;
    private bool _shouldTurnOn;
    private bool _shouldTurnOff;
    private EOnState _lastOnState;
    protected virtual void Start();
    private void Reset();
    protected virtual void OnUncappedMinPass();
    private void SetOnOffStatus();
    private void SetMaterial(bool insideTimeRange);
}