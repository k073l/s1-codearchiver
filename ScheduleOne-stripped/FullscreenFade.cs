using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.Platform;
using ScheduleOne.State;
using UnityEngine;

namespace ScheduleOne;
public class FullscreenFade : Singleton<FullscreenFade>
{
    private const float FadeDuration;
    private CanvasGroup _canvasGroup;
    private Coroutine _fadeCoroutine;
    private ScheduleOne.State.State _fullscreenFadeState;
    public bool IsOpen { get; private set; }

    protected override void Awake();
    protected override void Start();
    protected override void OnDestroy();
    public void Show();
    public void Hide();
    private void FadeTo(float alpha);
}