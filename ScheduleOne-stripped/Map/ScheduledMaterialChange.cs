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
    public Material OutsideTimeRangeMaterial;
    public Material InsideTimeRangeMaterial;
    public int TimeRangeMin;
    public int TimeRangeMax;
    public int TimeRangeShift;
    public int TimeRangeRandomization;
    [Range(0f, 1f)]
    public float TurnOnChance;
    private bool appliedInsideTimeRange;
    private EOnState onState;
    private int randomShift;
    protected virtual void Start();
    protected virtual void Tick();
    private void SetMaterial(bool insideTimeRange);
}