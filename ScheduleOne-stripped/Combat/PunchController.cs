using System.Collections;
using FishNet.Object;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dragging;
using ScheduleOne.FX;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Combat;
public class PunchController : MonoBehaviour
{
    public const float MAX_PUNCH_LOAD;
    public const float MIN_COOLDOWN;
    public const float MAX_COOLDOWN;
    public const float PUNCH_RANGE;
    public const float PUNCH_DEBOUNCE;
    [Header("Settings")]
    public Vector3 ViewmodelAvatarOffset;
    public float MinPunchDamage;
    public float MaxPunchDamage;
    public float MinPunchForce;
    public float MaxPunchForce;
    [Header("Stamina Settings")]
    public float MinStaminaCost;
    public float MaxStaminaCost;
    [Header("References")]
    public AudioSourceController PunchSound;
    public RuntimeAnimatorController PunchAnimator;
    private float punchLoad;
    private float remainingCooldown;
    private Player player;
    private Coroutine punchRoutine;
    private bool itemEquippedLastFrame;
    private float timeSincePunchingEnabled;
    public bool PunchingEnabled { get; set; } = true;
    public bool IsLoading => punchLoad > 0f;
    public bool IsPunching { get; private set; }

    private void Awake();
    private void Start();
    private void Update();
    private void LateUpdate();
    private void UpdateCooldown();
    private void UpdateInput();
    private bool CanStartLoading();
    private void StartLoad();
    private void Release();
    private void Punch(float power);
    private void ExecuteHit(float power);
    private void SetPunchingEnabled(bool enabled);
    private bool ShouldBeEnabled();
}