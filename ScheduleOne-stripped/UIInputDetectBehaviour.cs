using System;
using UnityEngine;

namespace ScheduleOne;
public class UIInputDetectBehaviour : MonoBehaviour
{
    private float initialHoldThreshold;
    private float repeatInterval;
    private float timer;
    private bool wasPressedLastFrame;
    private Action<float> onAction;
    public void Initialize(Action<float> action, float holdThreshold, float repeat);
    public void ResetData();
    public void DoUpdate(float value);
}