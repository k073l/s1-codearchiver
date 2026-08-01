using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class CanvasScaler : MonoBehaviour
{
    public static Action OnCanvasScaleFactorChanged;
    [Range(0f, 2f)]
    [SerializeField]
    [FormerlySerializedAs("ScaleMultiplier")]
    private float _scaleMultiplier;
    [Range(0f, 1f)]
    [SerializeField]
    private float _globalScaleInfluence;
    private CanvasScaler _canvasScaler;
    private Vector2 _defaultReferenceResolution;
    public static float GlobalScaleFactor { get; private set; } = 1f;
    public static float NormalizedCanvasScaleFactor => Mathf.InverseLerp(0.7f, 1.5f, GlobalScaleFactor);

    public void Awake();
    private void OnDestroy();
    private void RefreshScale();
    public static void SetScaleFactor(float scaleFactor);
}