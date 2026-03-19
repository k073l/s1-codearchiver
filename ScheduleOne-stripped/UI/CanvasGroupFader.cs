using System.Collections;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.UI;
[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFader : MonoBehaviour
{
    [SerializeField]
    private float _defaultFadeDuration;
    [SerializeField]
    private bool _scaleDurationWithFadeAmount;
    private CanvasGroup _canvasGroup;
    private Coroutine _fadeRoutine;
    private void Awake();
    public void FadeTo(float targetAlpha);
    public void FadeTo(float targetAlpha, float duration);
}