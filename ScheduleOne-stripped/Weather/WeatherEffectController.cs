using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
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
    [Header("Parameters: Audio")]
    [Tooltip("Min and max distance for audio effects. Max being the distance at which audio is inaudible, and min being the distance at which audio is at full volume")]
    [SerializeField]
    protected Vector2 _minMaxDistanceToPlayer;
    [Tooltip("Uses the blend value of weather volume to determine audio volume rather than distance to player")]
    [SerializeField]
    protected bool _useWeatherBlendForAudio;
    [Tooltip("Used to evaluate audio blending of audio volume (when using distance to player)")]
    [SerializeField]
    protected AnimationCurve _distanceCurve;
    [Tooltip("Used to evaluate audio blending from inside to outside")]
    [SerializeField]
    protected AnimationCurve _enclosureCurve;
    [Header("Parameters: Effects")]
    [Header("Settings: Player Following")]
    [SerializeField]
    protected List<EffectHandler> _effectsToFollowPlayer;
    [Header("Settings: Effects")]
    [SerializeField]
    protected List<EffectSettings> _effectSettings;
    [Header("Settings: Audio")]
    [SerializeField]
    protected List<ScheduleOne.Audio.AudioSettings> _audioSettings;
    [Header("Debugging & Development")]
    [SerializeField]
    protected bool _showGizmos;
    protected float _weatherBlend;
    protected WeatherVolume _mainVolume;
    protected WeatherVolume _neighbourVolume;
    private bool NetworkInitialize___EarlyScheduleOne_002EWeather_002EWeatherEffectControllerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EWeather_002EWeatherEffectControllerAssembly_002DCSharp_002Edll_Excuted;
    public string ControllerId => _controllerId;

    public override void Awake();
    protected virtual void Update();
    public void Initialise(WeatherVolume mainVolume);
    public void SetNeighbourVolume(WeatherVolume neighbourVolume);
    public override void Activate();
    public override void Deactivate();
    public void BlendEffects(float blend, AnimationCurve curve);
    private void SetEffectParamters(EffectHandler effectHandler, float blend, AnimationCurve curve);
    public void SetShaderNumericParameter(string paramater, float value);
    public void SetVisualEffectNumericParameter(string paramater, float value);
    public void SetShaderColorParameter(string paramater, Color value);
    public EffectSettings FindEffectSettings(string handlerId);
    protected virtual EffectSettings GetFromEffectSettings(string handlerId);
    public virtual void UpdateAudio();
    public override void UpdateProperties(Vector3 anchoredPosition, Vector3 playerPosition, float sqrDistanceToPlayer, float enclosureBlend);
    private void OnDrawGizmos();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected virtual void Awake_UserLogic_ScheduleOne_002EWeather_002EWeatherEffectController_Assembly_002DCSharp_002Edll();
}