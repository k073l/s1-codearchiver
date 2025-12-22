using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Growing;
public class GrowContainerSurfaceCover : MonoBehaviour
{
    public const int TextureSize;
    public const int PourRadius;
    public const int UpdatesPerSecond;
    public const float CoveredPixelThreshold;
    public const float Delay;
    [Header("Settings")]
    public float SuccessfulCoverageThreshold;
    [Header("References")]
    public GrowContainer GrowContainer;
    public MeshRenderer MeshRenderer;
    public Texture2D PourMask;
    [Header("Pour Over time Settings")]
    [SerializeField]
    private float _applyPoutOverTimeDuration;
    [SerializeField]
    private AnimationCurve _applyPoutOverTimeCurve;
    public UnityEvent onSufficientCoverage;
    private bool queued;
    private Vector3 queuedWorldPos;
    private Texture2D mainTex;
    private Texture2D tempTex;
    private Vector3 relative;
    private Vector2 vector2;
    private Vector2 normalizedOffset;
    private Vector2 originPixel;
    private float _pourApplicationStrength;
    public float CurrentCoverage { get; private set; }
    public float PourApplicationStrength { get; set; }
    public bool UseApplyOverTime { get; set; }
    private float _sideLength => GrowContainer.GetGrowSurfaceSideLength();

    private void Awake();
    private void OnEnable();
    public void ConfigureAppearance(Color col, float transparency);
    public void Reset();
    public void QueuePour(Vector3 worldSpacePosition);
    public float GetNormalizedProgress();
    private IEnumerator CheckQueue();
    private void Blank();
    private void DelayedApplyPour(Vector3 worldSpace);
    private void ApplyPour(Vector3 worldSpace, bool applyOverTime = false);
    private IEnumerator ApplyPourOverTime();
    private float GetPourMaskValue(int x, int y);
    private float GetCoverage();
}