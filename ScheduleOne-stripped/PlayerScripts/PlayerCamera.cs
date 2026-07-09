using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.Input;
using ScheduleOne.Reporting;
using ScheduleOne.Tools;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ScheduleOne.PlayerScripts;
public class PlayerCamera : PlayerSingleton<PlayerCamera>
{
    public enum ECameraMode
    {
        Default,
        Vehicle,
        Skateboard
    }

    private const float CameraShakeMultiplier;
    private const float MinFov;
    [Header("Settings")]
    public float cameraOffsetFromTop;
    public float SprintFoVBoost;
    public float FoVChangeRate;
    public float HorizontalCameraBob;
    public float VerticalCameraBob;
    public float BobRate;
    public AnimationCurve HorizontalBobCurve;
    public AnimationCurve VerticalBobCurve;
    public float FreeCamSpeed;
    public float FreeCamAcceleration;
    public bool SmoothLook;
    public float SmoothLookSpeed;
    public FloatSmoother FoVChangeSmoother;
    public FloatSmoother SmoothLookSmoother;
    [Header("References")]
    public Transform CameraContainer;
    public Camera Camera;
    public Camera OverlayCamera;
    public Animator Animator;
    public AnimationClip[] JoltClips;
    public UniversalRenderPipelineAsset[] URPAssets;
    public Transform ViewAvatarCameraPosition;
    public HeartbeatSoundController HeartbeatSoundController;
    public ParticleSystem Flies;
    public AudioSourceController MethRumble;
    public RandomizedAudioSourceController SchizoVoices;
    [Header("Input")]
    [SerializeField]
    private InputActionReference _viewAvatarAction;
    private Volume globalVolume;
    private DepthOfField DoF;
    private Coroutine cameraShakeCoroutine;
    private Vector3 cameraLocalPos;
    private Vector3 freeCamMovement;
    private Coroutine focusRoutine;
    private float focusMouseX;
    private float focusMouseY;
    private Dictionary<int, MotionEvent> movementEvents;
    private List<int> movementEventKeys;
    private float freeCamSpeed;
    private float mouseX;
    private float mouseY;
    private Vector3 cameralocalPos_PriorOverride;
    private Quaternion cameraLocalRot_PriorOverride;
    private Coroutine lerpCameraRoutine;
    private Vector2 seizureJitter;
    private float schizoFoV;
    private float timeUntilNextSchizoVoice;
    private bool _dofWasActiveBeforeScreenshot;
    private List<Vector3> gizmos;
    private Coroutine lookRoutine;
    private Coroutine DoFCoroutine;
    private Coroutine ILerpCameraFOV_Coroutine;
    public static GraphicsSettings.EAntiAliasingMode AntiAliasingMode { get; private set; }
    public bool CanLook { get; protected set; } = true;
    public int ActiveUIElementCount => activeUIElements.Count;
    public List<string> ActiveUIElements => activeUIElements;
    public bool FreeCamEnabled { get; private set; }
    public bool ViewingAvatar { get; private set; }
    public ECameraMode CameraMode { get; protected set; }
    public bool MethVisuals { get; set; }
    public bool CocaineVisuals { get; set; }
    public float FovJitter { get; private set; }
    public Vector3 Position { get; private set; } = Vector3.zero;
    private List<string> activeUIElements { get; set; } = new List<string>();
    private bool transformOverriden { get; set; }
    private bool fovOverriden { get; set; }

    protected override void Awake();
    public override void OnStartClient(bool IsOwner);
    protected override void Start();
    protected override void OnDestroy();
    private void PlayerSpawned();
    private void PrepForScreenshot();
    private void CleanupScreenshot();
    public static void SetAntialiasingMode(GraphicsSettings.EAntiAliasingMode mode);
    public void ApplyAASettings();
    protected virtual void Update();
    private void Screenshot();
    protected virtual void LateUpdate();
    private void Exit(ExitAction action);
    public float GetTargetLocalY();
    public void SetCameraMode(ECameraMode mode);
    private void RotateCamera();
    public void LockMouse(bool showCrosshair = true);
    public void FreeMouse(bool hideCrosshair = true);
    public bool LookRaycast(float range, out RaycastHit hit, LayerMask layerMask, bool includeTriggers = true, float radius = 0f);
    public bool LookRaycast_ExcludeBuildables(float range, out RaycastHit hit, LayerMask layerMask, bool includeTriggers = true);
    private void OnDrawGizmosSelected();
    public bool Raycast_ExcludeBuildables(Vector3 origin, Vector3 direction, float range, out RaycastHit hit, LayerMask layerMask, bool includeTriggers = false, float radius = 0f, float maxAngleDifference = 0f);
    public Ray GetPointerRay();
    public bool MouseRaycast(float range, out RaycastHit hit, LayerMask layerMask, bool includeTriggers = true, float radius = 0f);
    public bool LookSpherecast(float range, float radius, out RaycastHit hit, LayerMask layerMask);
    public void OverrideTransform(Vector3 worldPos, Quaternion rot, float lerpTime, bool keepParented = false);
    private IEnumerator LerpCameraTransform(Vector3 endPos, Quaternion endRot, float lerpTime, bool worldSpace, bool returnToRestingPosition, bool enableLookWhenDone);
    public void StopTransformOverride(float lerpTime, bool reenableCameraLook = true, bool returnToOriginalRotation = true);
    public void LookAt(Vector3 point, float duration = 0.25f);
    public void SetCanLook(bool canLook);
    public void SetDoFActive(bool active, float lerpTime);
    private IEnumerator LerpDoF(bool active, float lerpTime);
    public void OverrideFOV(float fov, float lerpTime);
    protected IEnumerator ILerpFOV(float endFov, float lerpTime);
    public void StopFOVOverride(float lerpTime);
    public void AddActiveUIElement(string name);
    public void RemoveActiveUIElement(string name);
    public void RegisterMovementEvent(int threshold, Action action);
    public void DeregisterMovementEvent(Action action);
    private void UpdateMovementEvents();
    private void ViewAvatar();
    private void StopViewingAvatar();
    public void JoltCamera();
    public bool PointInCameraView(Vector3 point);
    public bool Is01(float a);
    public void ResetRotation();
    public void FocusCameraOnTarget(Transform target);
    public void StopFocus();
    public void StartCameraShake(float intensity, float duration = -1f, bool decreaseOverTime = true);
    public void StopCameraShake();
    public void UpdateCameraBob();
    public void SetFreeCam(bool enable, bool reenableLook = true);
    private void RotateFreeCam();
    private void UpdateFreeCamInput();
    private void MoveFreeCam();
}