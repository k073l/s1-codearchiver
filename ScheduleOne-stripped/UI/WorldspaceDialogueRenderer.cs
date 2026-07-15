using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using TMPro;
using UnityEngine;

namespace ScheduleOne.UI;
public class WorldspaceDialogueRenderer : MonoBehaviour
{
    private const float FadeDist;
    [Header("Settings")]
    public float MaxRange;
    public float BaseScale;
    public AnimationCurve Scale;
    public Vector2 Padding;
    public Vector3 WorldSpaceOffset;
    [Header("References")]
    public Canvas Canvas;
    public CanvasGroup CanvasGroup;
    public RectTransform Background;
    public TextMeshProUGUI Text;
    public Animation Anim;
    private Vector3 _localOffset;
    private float _currentOpacity;
    private Coroutine _hideCoroutine;
    public bool IsVisible { get; private set; }
    public string ShownText { get; private set; } = string.Empty;

    private void Awake();
    private void OnDestroy();
    private void OnStateChange(IState newState);
    private void Update();
    private void LateUpdate();
    private void UpdatePosition();
    public void ShowText(string text, float duration = 0f);
    public void HideText();
    private void SetOpacity(float op);
}