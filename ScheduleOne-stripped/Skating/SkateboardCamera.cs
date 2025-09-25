using System;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Skating;
[RequireComponent(typeof(Skateboard))]
public class SkateboardCamera : NetworkBehaviour
{
    private const float followDelta;
    private const float yMinLimit;
    private const float manualOverrideTime;
    private const float manualOverrideReturnTime;
    private const float xSpeed;
    private const float ySpeed;
    private const float yMaxLimit;
    [Header("References")]
    public Transform cameraOrigin;
    [Header("Settings")]
    public float CameraFollowSpeed;
    public float HorizontalOffset;
    public float VerticalOffset;
    public float CameraDownAngle;
    [Header("Settings")]
    public float FOVMultiplier_MinSpeed;
    public float FOVMultiplier_MaxSpeed;
    public float FOVMultiplierChangeRate;
    private Skateboard board;
    private float currentFovMultiplier;
    private bool cameraReversed;
    private bool cameraAdjusted;
    private float timeSinceCameraManuallyAdjusted;
    private float orbitDistance;
    private Vector3 lastFrameCameraOffset;
    private Vector3 lastManualOffset;
    private Transform targetTransform;
    private Transform cameraDolly;
    private float x;
    private float y;
    private float mouseIdleCooldown;
    private float mouseIdleTimer;
    private bool NetworkInitialize___EarlyScheduleOne_002ESkating_002ESkateboardCameraAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ESkating_002ESkateboardCameraAssembly_002DCSharp_002Edll_Excuted;
    private Transform cam => ((Component)PlayerSingleton<PlayerCamera>.Instance).transform;
    private bool NeedSecondaryClick => GameInput.CurrentInputDevice == GameInput.InputDeviceType.KeyboardMouse;

    public override void Awake();
    private void OnPlayerMountedSkateboard(Skateboard skateboard);
    public override void OnStartClient();
    private void OnDestroy();
    private void Update();
    private void CheckForClick();
    private void CheckForMouseMovement();
    private void LateUpdate();
    private void UpdateCamera();
    private void HandleNonSecondaryClickCameraMovement();
    private void HandleSecondaryClickCameraMovement();
    private void UpdateFOV();
    private void ForceCameraReturn();
    private static float ClampAngle(float angle, float min, float max);
    private Vector3 GetTargetCameraPosition();
    private Vector3 LimitCameraPosition(Vector3 targetPosition);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void Awake_UserLogic_ScheduleOne_002ESkating_002ESkateboardCamera_Assembly_002DCSharp_002Edll();
}