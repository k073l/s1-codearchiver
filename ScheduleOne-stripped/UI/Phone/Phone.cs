using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using ScheduleOne.Vision;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone;
public class Phone : PlayerSingleton<Phone>
{
    private const float MinLookOffset;
    private const float MaxLookOffset;
    private const float RotationTime;
    public static GameObject ActiveApp;
    [Header("References")]
    [SerializeField]
    protected GameObject phoneModel;
    [SerializeField]
    protected Transform orientation_Vertical;
    [SerializeField]
    protected Transform orientation_Horizontal;
    [SerializeField]
    protected GraphicRaycaster raycaster;
    [SerializeField]
    protected GameObject PhoneFlashlight;
    [SerializeField]
    protected AudioSourceController FlashlightToggleSound;
    [SerializeField]
    protected MonoState state;
    [Header("Fonts")]
    [SerializeField]
    private ColorFont _generalColorFont;
    [SerializeField]
    private ColorFont _productColorFont;
    [Header("Input")]
    [SerializeField]
    private InputActionReference _toggleFlashlightInputAction;
    public Action onPhoneOpened;
    public Action onPhoneClosed;
    public Action closeApps;
    private EventSystem eventSystem;
    private VisibilityAttribute flashlightVisibility;
    private Coroutine rotationCoroutine;
    private Coroutine lookOffsetCoroutine;
    public bool IsOpen { get; protected set; }
    public bool isHorizontal { get; protected set; }
    public bool isOpenable { get; protected set; } = true;
    public bool FlashlightOn { get; protected set; }
    public bool IsAnyAppOpen => (Object)(object)ActiveApp != (Object)null;
    public MonoState State => state;
    public float ScaledLookOffset => Mathf.Lerp(2f, 1.4f, CanvasScaler.NormalizedCanvasScaleFactor);
    public ColorFont GeneralColorFont => _generalColorFont;

    protected override void Awake();
    public override void OnStartClient(bool IsOwner);
    protected override void Start();
    protected virtual void Update();
    protected override void OnDestroy();
    private void ToggleFlashlight();
    public void SetIsOpen(bool o);
    public void SetIsActiveGameplayScreen(bool isActive);
    public void SetIsHorizontal(bool h);
    protected IEnumerator SetIsHorizontal_Process(bool h);
    public void SetLookOffsetMultiplier(float multiplier);
    public void RequestCloseApp();
    protected IEnumerator SetLookOffset_Process(float lookOffset);
    public bool MouseRaycast(out RaycastResult result);
}