using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.ScriptableObjects;
using ScheduleOne.Vision;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone;
public class Phone : PlayerSingleton<Phone>
{
    public static GameObject ActiveApp;
    public PhoneCallData testData;
    public CallerID testCalller;
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
    [Header("Settings")]
    public float rotationTime;
    public float LookOffsetMax;
    public float LookOffsetMin;
    public float OpenVerticalOffset;
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
    public float ScaledLookOffset => Mathf.Lerp(LookOffsetMax, LookOffsetMin, CanvasScaler.NormalizedCanvasScaleFactor);

    protected override void Awake();
    public override void OnStartClient(bool IsOwner);
    protected override void Start();
    protected virtual void Update();
    protected override void OnDestroy();
    private void ToggleFlashlight();
    public void SetOpenable(bool o);
    public void SetIsOpen(bool o);
    public void SetIsHorizontal(bool h);
    protected IEnumerator SetIsHorizontal_Process(bool h);
    public void SetLookOffsetMultiplier(float multiplier);
    public void RequestCloseApp();
    protected IEnumerator SetLookOffset_Process(float lookOffset);
    public bool MouseRaycast(out RaycastResult result);
}