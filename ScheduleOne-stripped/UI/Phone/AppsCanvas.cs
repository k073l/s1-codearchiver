using System;
using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI.Tooltips;
using UnityEngine;

namespace ScheduleOne.UI.Phone;
public class AppsCanvas : PlayerSingleton<AppsCanvas>
{
    [Header("References")]
    public Canvas canvas;
    private Coroutine delayedSetOpenRoutine;
    public bool isOpen { get; private set; }

    protected override void Awake();
    public override void OnStartClient(bool IsOwner);
    protected void PhoneOpened();
    protected void PhoneClosed();
    private IEnumerator DelayedSetCanvasActive(bool active, float delay);
    public void SetIsOpen(bool o);
    private void SetCanvasActive(bool a);
    protected override void Start();
}