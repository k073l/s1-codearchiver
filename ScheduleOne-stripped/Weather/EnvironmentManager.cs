using System;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Transporting;
using ScheduleOne.Core.Utilities;
using ScheduleOne.Core.Weather;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Persistence;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

namespace ScheduleOne.Weather;
public class EnvironmentManager : NetworkSingleton<EnvironmentManager>, IEnvironmentManager
{
    private const float UpdateWeatherEntitiesTickRate;
    [Header("General Components")]
    [SerializeField]
    private Transform _playerObj;
    [Header("Controllers")]
    [SerializeField]
    private DayNightController _dayNightController;
    [SerializeField]
    private MaskController _maskController;
    [Header("Weather Components")]
    [SerializeField]
    private WeatherVolume _weatherVolumePrefab;
    [SerializeField]
    private Transform _weatherBoundsAnchor;
    [SerializeField]
    private Transform _weatherVolumeContainer;
    [Header("Weather Profiles")]
    [SerializeField]
    private List<WeatherSequence> _weatherSequences;
    [SerializeField]
    private List<WeightedWeatherSequence> _dailyWeatherSequences;
    [SerializeField]
    private List<WeatherProfile> _weatherProfiles;
    [Header("Weather Settings")]
    [SerializeField]
    private float _defaultWeatherVolumeMoveSpeed;
    [SerializeField]
    [Range(1f, 6f)]
    private int _weatherVolumeCount;
    [SerializeField]
    private Vector3 _weatherBounds;
    [SerializeField]
    [Range(0f, 1f)]
    private float _weatherVolumeBlendSize;
    [SerializeField]
    private AnimationCurve _blendCurve;
    [Header("Lighting Settings")]
    [SerializeField]
    private LensFlareSettings _lensFlareSettings;
    [Header("Wind Settings")]
    [SerializeField]
    private float _windChangeSpeed;
    [SerializeField]
    private Vector2Int _minMaxWindChangeInterval;
    [SerializeField]
    [Range(0f, 360f)]
    private float _windChangeAngle;
    [SerializeField]
    private Vector2Int _minMaxWindShiftInterval;
    [SerializeField]
    [Range(0f, 360f)]
    private float _windShiftAngle;
    [Header("Debugging & Development")]
    [SerializeField]
    private UniversalRendererData _rendererData;
    [SerializeField]
    private bool _debugControlWeatherSpeedWithSlider;
    [SerializeField]
    [Range(0f, 1f)]
    private float _debugWeatherSliderValue;
    private List<WeatherEnclosure> _weatherEnclosures;
    private List<SkyOverrideEnclosure> _overrideEnclosures;
    [SyncObject]
    private readonly SyncList<WeatherVolume> _activeWeatherVolumes;
    private WeatherSequence _currentWeatherSequence;
    private WeatherVolume _targetWeatherVolume;
    private Vector3 _weatherVolumeBounds;
    private Vector3 _weatherBoundsCenter;
    private SkySettings _skyOverrideSettings;
    private float _blendAmount;
    private float _skyOverrideBlendValue;
    private bool _doWeatherBlending;
    private bool _hasWeatherVolumeNeighbour;
    private bool _withinBounds;
    private int _targetWeatherVolumeIndex;
    private int _neighbourWeatherVolumeIndex;
    private float _targetWeatherBlendValue;
    private float _weatherVolumeMoveSpeed;
    private float _neighbourWeatherBlendValue;
    private Vector2 _closestPointInTargetVolume;
    private Vector2 _closestPointInNeighbourVolume;
    private int _sequenceVolumeStartIndex;
    private Vector3[] _weatherVolumePositions;
    private Vector3 _windVelocity;
    private Vector3 _targetWindDirection;
    private Vector3 _currentWindDirection;
    private float _windChangeTime;
    private float _windShiftTime;
    private float _windShiftTimer;
    private float _windChangeTimer;
    private WeatherConditions _currentWeatherConditions;
    private SkyState _currentSkyState;
    protected ScheduleOneFogFeature _fogFeature;
    private List<IWeatherEntity> _registeredWeatherEntities;
    private bool NetworkInitialize___EarlyScheduleOne_002EWeather_002EEnvironmentManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EWeather_002EEnvironmentManagerAssembly_002DCSharp_002Edll_Excuted;
    protected Transform Player => GetPlayer();

    SkyState IEnvironmentManager.SkyState => _currentSkyState;
    public List<WeatherSequence> WeatherSequences => _weatherSequences;

    public override void Awake();
    protected override void Start();
    public override void OnStartServer();
    private void SetupHandler();
    private void InitialiseFog();
    private void InitialiseSky();
    private void InitialiseWind();
    private void InitialiseWeather();
    private void InitialiseGlobalVariables();
    private void SetupEvents();
    private void InitialiseControllers();
    private void Update();
    private void CreateWeatherVolumesAtStartIndex(int sequenceVolumeIndex);
    private void CreateVolume(WeatherProfile profile, Vector3 position, int insertIndex = -1);
    private void DetermineWeatherVolumeWithTarget();
    private void CalculateWeatherBlendsFromVolumes();
    private void BlendWeatherProfiles();
    private void CreateWeatherVolumes();
    private void MoveWeatherVolumes();
    private void UpdateWind();
    private void ChangeWindDirection();
    private void ShiftWindDirection();
    public Vector3 GetNewWindDirection(float changeAngle, Vector3 currentDirection);
    private void UpdateVolumes();
    private void UpdateWeather();
    private void UpdateWeatherEntities();
    private void SetLensFlare(LensFlareDataSRP flare, float intensity);
    private void ClearWeather();
    private void SetRandomWeatherSequence();
    protected WeatherProfile GetWeatherProfileFromPosition(Vector3 position);
    private WeatherConditions GetActiveWeatherConditionsFromPosition(Vector3 position);
    private Vector3 GetWeatherVolumeBounds();
    private Vector3 GetWeatherVolumeInitialPosition();
    private Vector3 GetWeatherBoundsCenter();
    private Transform GetWeatherAnchor();
    private Transform GetPlayer();
    private bool IsPositionUnderCover(Vector3 position);
    private int GetWrappedIndex(int index, int change, int size);
    public WeatherProfile GetWeatherProfile(string id);
    private void OnMinutePass();
    private void OnTick();
    private void OnTimeSet();
    private void OnSleepEnd();
    public void SetWeather(string type);
    public void OnWeatherEntityRegistered(IWeatherEntity entity);
    public void OnWeatherEntityUnregistered(IWeatherEntity entity);
    public void OnEnclosureRegistered(WorldEnclosure enclosure);
    private void RegisterEnclosure(WorldEnclosure enclosure);
    private void RegisterWeatherEnclosure(WeatherEnclosure enclosure);
    private void RegisterOverrideEnclosure(SkyOverrideEnclosure enclosure);
    protected override void OnDestroy();
    private void SetWeatherSequence(string sequenceId);
    public void TriggerLightningEvent();
    public void TriggerTargetedLightningEvent(Vector3 target);
    public void TriggerDistantThunder();
    private ThunderController GetActiveThunderController();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002EWeather_002EEnvironmentManager_Assembly_002DCSharp_002Edll();
}