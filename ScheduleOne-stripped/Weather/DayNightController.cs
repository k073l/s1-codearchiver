using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Weather;
public class DayNightController : MonoBehaviour
{
    private const float SunShadowStrength;
    private const float MoonShadowStrength;
    [Header("Components")]
    [SerializeField]
    private GameObject _lightPivot;
    [SerializeField]
    private MeshRenderer _skyRenderer;
    [Header("Lights")]
    [SerializeField]
    private Light _sunLight;
    [SerializeField]
    private Light _moonLight;
    [SerializeField]
    private Light _ambientLight;
    [SerializeField]
    private AnimationCurve _fadeInCurve;
    [SerializeField]
    private AnimationCurve _fadeOutCurve;
    [Header("Debugging & Development")]
    [SerializeField]
    private float _debugTimeSpeed;
    [SerializeField]
    private bool _enableDebugTimeControl;
    [SerializeField]
    private bool _debugAutoUpdateTime;
    [SerializeField]
    [Range(0f, 24f)]
    private float _timeInHours;
    private float _timePercentage;
    private bool _isDay;
    private Quaternion _currentSunRotation;
    private Quaternion _currentMoonRotation;
    [SerializeField]
    private DayNightPhaseTimes _dayNightPhaseTimes;
    public const float MAX_LIGHT_INTENSITY;
    public bool EnableDebugTimeControl => _enableDebugTimeControl;

    private void Update();
    public SkyState EvaluateSky(SkySettings activeSettings, SkySettings neighbourSettings, float blend, SkySettings overrideSkySettings = null, float overrideBlend = 0f);
    private SkyState EvaluateSky(SkyState state, SkySettings activeSettings, SkySettings neighbourSettings, float blend, float timeInTwentyFourHour, float timePercentage);
    private SkyState BlendSky(SkyState from, SkyState to, float blend);
    public float EvaluateFloatByTimeOfDay(DynamicGradient gradient);
    public Color EvaluateColorByTimeOfDay(DynamicGradient gradient);
    private void UpdateSky(SkyState skyState);
    private void SetLights(bool isDay);
    private void UpdateRotation();
    private void SnapRotation();
    public void SetRotation();
    public void OnTick(float normalisedTime);
    public void OnTimeSet(float normalisedTime);
    private bool IsDay(float timeInTwentyFourHour);
}