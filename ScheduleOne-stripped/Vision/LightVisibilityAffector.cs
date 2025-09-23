using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.FX;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Vision;
[RequireComponent(typeof(Light))]
public class LightVisibilityAffector : MonoBehaviour
{
    public const float PointLightEffect;
    public const float SpotLightEffect;
    [Header("Settings")]
    public float EffectMultiplier;
    public string uniquenessCode;
    [Tooltip("How far does the player have to move for visibility to be recalculated?")]
    public int updateDistanceThreshold;
    protected Light light;
    protected VisibilityAttribute attribute;
    protected virtual void Awake();
    private void PlayerSpawned();
    private void OnDestroy();
    protected virtual void UpdateVisibility();
    private void UpdateAttribute(float visibity);
    private void ClearAttribute();
}