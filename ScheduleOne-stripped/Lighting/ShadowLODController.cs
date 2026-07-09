using System;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Lighting;
public class ShadowLODController : MonoBehaviour
{
    private const int RefreshMovementThreshold;
    [SerializeField]
    private bool _softShadowEnabled;
    [SerializeField]
    private Light[] _lights;
    [SerializeField]
    [Conditional("_softShadowEnabled", false)]
    private float _softShadowDistance;
    [SerializeField]
    private float _hardShadowDistance;
    private float _softShadowDistanceSqr;
    private float _hardShadowDistanceSqr;
    private LightShadows _appliedShadowsMode;
    private void Awake();
    private void OnEnable();
    private void OnDestroy();
    public void UpdateShadows();
    private void RecalculateDistances();
}