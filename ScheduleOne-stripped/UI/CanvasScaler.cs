using System;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
[RequireComponent(typeof(CanvasScaler))]
public class CanvasScaler : MonoBehaviour
{
    public static float CanvasScaleFactor;
    public static Action OnCanvasScaleFactorChanged;
    public float ScaleMultiplier;
    private Vector2 referenceResolution;
    private CanvasScaler canvasScaler;
    public static float NormalizedCanvasScaleFactor => Mathf.InverseLerp(0.7f, 1.4f, CanvasScaleFactor);

    public void Awake();
    private void OnDestroy();
    private void RefreshScale();
    public static void SetScaleFactor(float scaleFactor);
}