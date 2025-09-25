using System.Collections;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.UI;
public class BlackOverlay : Singleton<BlackOverlay>
{
    [Header("References")]
    public Canvas canvas;
    public CanvasGroup group;
    private Coroutine fadeRoutine;
    public bool isShown { get; protected set; }

    protected override void Awake();
    public void Open(float fadeTime = 0.5f);
    public void Close(float fadeTime = 0.5f);
    private IEnumerator Fade(float endOpacity, float fadeTime);
}