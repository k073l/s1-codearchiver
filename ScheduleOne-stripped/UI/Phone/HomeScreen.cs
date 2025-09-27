using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone;
public class HomeScreen : PlayerSingleton<HomeScreen>
{
    [Header("References")]
    [SerializeField]
    protected Canvas canvas;
    [SerializeField]
    protected Text timeText;
    [SerializeField]
    protected RectTransform appIconContainer;
    [Header("Prefabs")]
    [SerializeField]
    protected GameObject appIconPrefab;
    protected List<Button> appIcons;
    private Coroutine delayedSetOpenRoutine;
    public bool isOpen { get; protected set; } = true;

    protected override void Start();
    public override void OnStartClient(bool IsOwner);
    protected override void OnDestroy();
    protected void PhoneOpened();
    protected void PhoneClosed();
    private IEnumerator DelayedSetCanvasActive(bool active, float delay);
    public void SetIsOpen(bool o);
    public void SetCanvasActive(bool a);
    protected virtual void Update();
    protected virtual void MinPass();
    public Button GenerateAppIcon<T>(App<T> prog)
        where T : PlayerSingleton<T>;
}