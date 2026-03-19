using System;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Transporting;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

namespace ScheduleOne.Weather;
public class EnvironmentManager : NetworkSingleton<EnvironmentManager>
{
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
    private Transform _weatherBoundsAnchor;
    [SerializeField]
    private Transform _weatherVolumeContainer;
    [Header("Weather Profiles")]
    [SerializeField]
    private List<WeatherSequence> _weatherSequences;
    [SerializeField]
    private List<WeightedWeatherSequence> _dailyWeatherSequences;
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
    private List<PuddleVolume> _puddleVolumes;
    [SyncObject]
    private readonly SyncList<WeatherVolume> _activeWeatherVolumes;
    private WeatherSequence _currentWeatherSequence;
    private WeatherVolume _targetWeatherVolume;
    private Vector3 _weatherVolumeBounds;
    private Vector3 _weatherBoundsCenter;
    private SkySettings _skyOverrideSettings;
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
    private float _wetUpdateTimer;
    private int _sequenceVolumeStartIndex;
    private Vector3[] _weatherVolumePositions;
    private WeatherConditions _currentWeatherConditions;
    private SkyState _currentSkyState;
    protected ScheduleOneFogFeature _fogFeature;
    private List<IWeatherEntity> _registeredWeatherEntities;
    private bool NetworkInitialize___EarlyScheduleOne_002EWeather_002EEnvironmentManagerAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EWeather_002EEnvironmentManagerAssembly_002DCSharp_002Edll_Excuted;
    public WeatherConditions CurrentWeatherConditions => _currentWeatherConditions;
    public SkyState CurrentSkyState => _currentSkyState;
    protected Transform Player => GetPlayer();

    public override void Awake();
    protected override void Start();
    public override void OnStartServer();
    private void Update();
    private void InitialiseControllers();
    private void InitialiseSky();
    private void InitialiseWeather();
    private void InitialiseGlobalVariables();
    private void CreateWeatherVolumesAtStartIndex(int sequenceVolumeIndex);
    private void CreateVolume(WeatherVolume volume, Vector3 position, int insertIndex = -1);
    private WeatherProfile GetNextWeatherProfile(WeatherProfile currentProfile);
    private void DetermineWeatherVolumeWithTarget();
    private void CalculateWeatherBlendsFromVolumes();
    private void BlendWeatherProfiles();
    private void CreateWeatherVolumes();
    private void MoveWeatherVolumes();
    public int GetSequenceStartTime(WeatherSequence sequence);
    private void UpdateVolumes();
    private void UpdateWeather();
    private void UpdateWeatherEntities();
    private void SetRandomWeatherSequence();
    private void SetLensFlare(LensFlareDataSRP flare, float intensity);
    private void ClearWeather();
    public void RegisterEnclosure(WorldEnclosure enclosure);
    private void RegisterWeatherEnclosure(WeatherEnclosure enclosure);
    private void RegisterOverrideEnclosure(SkyOverrideEnclosure enclosure);
    public void RegisterPuddleVolume(PuddleVolume puddleVolume);
    private void SetWeatherConditions(WeatherConditions conditions);
    protected WeatherProfile GetWeatherProfileFromPosition(Vector3 position);
    public WeatherConditions GetActiveWeatherConditionsFromPosition(Vector3 position);
    private Vector3 GetWeatherVolumeBounds();
    private Vector3 GetWeatherVolumeInitialPosition();
    private Vector3 GetWeatherBoundsCenter();
    private Transform GetWeatherAnchor();
    private void OnMinutePass();
    private void OnTick();
    public void OnTimeSet();
    public void OnSleepEnd();
    private Transform GetPlayer();
    public bool IsPositionUnderCover(Vector3 position);
    public void OnWeatherEntityRegistered(IWeatherEntity entity);
    public void OnWeatherEntityUnregistered(IWeatherEntity entity);
    protected override void OnDestroy();
    [Button]
    public void SetDebugSequence();
    [Button]
    public void SetWeather(string type);
    private void SetWeatherSequence(string sequenceId);
    public void StopVolumeMovement();
    public void StartVolumeMovement();
    public void SetVolumeMoveSpeed(float speed);
    public void TriggerLightningEvent();
    public void TriggerPlayerLightningEvent(Player player);
    public void TriggerNpcLightningEvent(NPC npc);
    public void TriggerDistantThunder();
    private ThunderController GetActiveThunderController();
    private void SetWeather_Client();
    private void SetWeatherSpeed_Client();
    private void TriggerThunder_Client();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    protected override void Awake_UserLogic_ScheduleOne_002EWeather_002EEnvironmentManager_Assembly_002DCSharp_002Edll();
}