using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Temperature;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class TemperatureDisplay : MonoBehaviour
{
    public const float MaxCameraDistance;
    public const float MinCameraDistance;
    public const float FadeInDistance;
    public const float FadeOutDistance;
    public bool UseColor;
    [SerializeField]
    private Gradient _temperatureColorGradient;
    [SerializeField]
    private TextMeshPro _label;
    private Func<float> _getCelsiusTemperature;
    private Func<bool> _getIsVisible;
    private void Awake();
    private void LateUpdate();
    private void UpdateCanvas();
    public void SetTemperatureGetter(Func<float> getCelsiusTemperature);
    public void SetVisibilityGetter(Func<bool> getIsVisible);
    public void SetEnabled(bool enabled);
}