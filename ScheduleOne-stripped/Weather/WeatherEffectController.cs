using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.Core.Audio;
using ScheduleOne.Core.Effects;
using ScheduleOne.Core.Utilities;
using ScheduleOne.Core.Weather;
using ScheduleOne.Effects;
using UnityEngine;

namespace ScheduleOne.Weather;
public class WeatherEffectController : EffectController
{
    [Header("Components")]
    [SerializeField]
    protected List<ParticleEffectHandler> particleEffects;
    [SerializeField]
    protected List<VFXEffectHandler> visualEffects;
    [SerializeField]
    protected List<ShaderEffectHandler> shaderEffects;
    [SerializeField]
    protected List<AudioSourceController> _audioSources;
    [Header("Parameters: general")]
    [SerializeField]
    protected string _controllerId;
    [Header("Debugging & Development")]
    [SerializeField]
    protected bool _showGizmos;
    protected Vector2 _minMaxDistanceToPlayer;
    protected AnimationCurve _distanceCurve;
    protected AnimationCurve _enclosureCurve;
    protected List<EffectSettings> _effectSettings;
    protected List<AudioSettings> _audioSettings;
    protected float _weatherBlend;
    protected WeatherVolume _mainVolume;
    protected WeatherVolume _neighbourVolume;
    protected bool _audioRequiresUpdate;
    private bool NetworkInitialize___EarlyScheduleOne_002EWeather_002EWeatherEffectControllerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EWeather_002EWeatherEffectControllerAssembly_002DCSharp_002Edll_Excuted;
    public string ControllerId => _controllerId;

    public override void Awake();
    protected virtual void Update();
    public virtual void Initialise(WeatherVolume mainVolume, WeatherSettings weatherSettings);
    public void SetNeighbourVolume(WeatherVolume neighbourVolume);
    public override void Activate();
    public override void Deactivate();
    public void BlendEffects(float blend, AnimationCurve curve);
    private void SetEffectParamters(EffectHandler effectHandler, float blend, AnimationCurve curve);
    public void SetShaderNumericParameter(string paramater, float value);
    public void SetVisualEffectNumericParameter(string paramater, float value);
    public void SetShaderColorParameter(string paramater, Color value);
    public void SetVisualEffectColorParameter(string paramater, Color value);
    public EffectSettings FindEffectSettings(string handlerId);
    protected virtual EffectSettings GetFromEffectSettings(string handlerId);
    protected void SetAudio(AudioSourceController controller, AudioSettingsWrapper settings);
    public virtual bool UpdateAudio();
    public override void UpdateProperties(Vector3 anchoredPosition, Vector3 playerPosition, float sqrDistanceToPlayer, float enclosureBlend, float enclosurePan);
    private void OnDrawGizmos();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected virtual void Awake_UserLogic_ScheduleOne_002EWeather_002EWeatherEffectController_Assembly_002DCSharp_002Edll();
}