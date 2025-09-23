using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Vehicles;
public class VehicleCamera : MonoBehaviour
{
    private const float followDelta;
    private const float yMinLimit;
    private const float manualOverrideTime;
    private const float manualOverrideReturnTime;
    private const float xSpeed;
    private const float ySpeed;
    private const float yMaxLimit;
    [Header("References")]
    public LandVehicle vehicle;
    [Header("Camera Settings")]
    [SerializeField]
    protected Transform cameraOrigin;
    [SerializeField]
    protected float lateralOffset;
    [SerializeField]
    protected float verticalOffset;
    protected bool cameraReversed;
    protected float timeSinceCameraManuallyAdjusted;
    protected float orbitDistance;
    protected Vector3 lastFrameCameraOffset;
    protected Vector3 lastManualOffset;
    private Transform targetTransform;
    private Transform cameraDolly;
    private float x;
    private float y;
    private float mouseIdleCooldown;
    private float mouseIdleTimer;
    private Transform cam => ((Component)PlayerSingleton<PlayerCamera>.Instance).transform;
    private bool NeedSecondaryClick => GameInput.CurrentInputDevice == GameInput.InputDeviceType.KeyboardMouse;

    protected virtual void Start();
    private void Subscribe();
    protected virtual void Update();
    private void PlayerEnteredVehicle(LandVehicle veh);
    private void CheckForClick();
    private void CheckForMouseMovement();
    protected virtual void LateUpdate();
    private void HandleNonSecondaryClickCameraMovement();
    private void HandleSecondaryClickCameraMovement();
    private void ForceCameraReturn();
    private static float ClampAngle(float angle, float min, float max);
    private Vector3 GetTargetCameraPosition();
    private Vector3 LimitCameraPosition(Vector3 targetPosition);
}