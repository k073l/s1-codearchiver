using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Map;
using UnityEngine;

namespace ScheduleOne.Cartel;
public class CartelActivity : MonoBehaviour
{
    [Header("Settings")]
    [Range(0f, 1f)]
    public float InfluenceRequirement;
    public Action onActivated;
    public Action onDeactivated;
    public bool IsActive { get; protected set; }
    public int MinsSinceActivation { get; protected set; }
    public EMapRegion Region { get; protected set; }

    private void Start();
    public virtual void Activate(EMapRegion region);
    protected virtual void MinPassed();
    protected virtual void HourPassed();
    protected virtual void Deactivate();
    public virtual bool IsRegionValidForActivity(EMapRegion region);
}