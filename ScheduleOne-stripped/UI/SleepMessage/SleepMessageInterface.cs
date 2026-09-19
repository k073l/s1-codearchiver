using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.State;
using TMPro;
using UnityEngine;

namespace ScheduleOne.UI.SleepMessage;
public class SleepMessageInterface : Singleton<SleepMessageInterface>
{
    public const float DefaultFadeDuration;
    [Header("References")]
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private TextMeshProUGUI _label;
    [SerializeField]
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private MonoState _state;
    private Coroutine _fadeCoroutine;
    protected override void Start();
    public void Open(string message, float fadeDuration = 0.8f);
    public void Close(float fadeDuration = 0.8f);
    private IEnumerator SetAlpha(float alpha, float fadeDuration);
}