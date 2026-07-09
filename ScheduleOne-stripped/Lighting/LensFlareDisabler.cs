using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScheduleOne.Lighting;
[RequireComponent(typeof(LensFlareComponentSRP))]
public class LensFlareDisabler : MonoBehaviour
{
    private const int RefreshDistance;
    public LensFlareComponentSRP lensFlare;
    public OptimizedLight optimizedLight;
    private float threshold;
    private void Awake();
    private void OnDestroy();
    private void Refresh();
}