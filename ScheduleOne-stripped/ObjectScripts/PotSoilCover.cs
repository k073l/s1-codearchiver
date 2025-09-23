using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.ObjectScripts;
public class PotSoilCover : MonoBehaviour
{
    public const int TEXTURE_SIZE;
    public const int POUR_RADIUS;
    public const int UPDATES_PER_SECOND;
    public const float COVERAGE_THRESHOLD;
    public const float BASE_COVERAGE;
    public const float SUCCESS_COVERAGE_THRESHOLD;
    public const float DELAY;
    public float CurrentCoverage;
    [Header("Settings")]
    public float Radius;
    [Header("References")]
    public MeshRenderer MeshRenderer;
    public Texture2D PourMask;
    public UnityEvent onSufficientCoverage;
    private bool queued;
    private Vector3 queuedWorldPos;
    private Texture2D mainTex;
    private Vector3 relative;
    private Vector2 vector2;
    private Vector2 normalizedOffset;
    private Vector2 originPixel;
    private void Awake();
    private void OnEnable();
    public void ConfigureAppearance(Color col, float transparency);
    public void Reset();
    public void QueuePour(Vector3 worldSpacePosition);
    public float GetNormalizedProgress();
    private IEnumerator CheckQueue();
    private void Blank();
    private void DelayedApplyPour(Vector3 worldSpace);
    private void ApplyPour(Vector3 worldSpace);
    private float GetPourMaskValue(int x, int y);
    private float GetCoverage();
}