using System.Collections.Generic;
using FishNet;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Weather;
public class WeatherVolume : NetworkBehaviour
{
    [Header("Controllers")]
    [SerializeField]
    private List<WeatherEffectController> _effectControllers;
    [Header("Profile")]
    [SerializeField]
    private WeatherProfile _weatherProfile;
    [Header("Debugging & Development")]
    [SerializeField]
    private bool _showGizmos;
    private Vector3 _weatherBounds;
    private Vector3 _volumeSize;
    private Vector3 _blendSize;
    private Vector3 _anchorPosition;
    private float _blendAmount;
    private bool _isInitialized;
    private Vector3 _velocity;
    private bool NetworkInitialize___EarlyScheduleOne_002EWeather_002EWeatherVolumeAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EWeather_002EWeatherVolumeAssembly_002DCSharp_002Edll_Excuted;
    public float BlendAmount => _blendAmount;
    public Vector3 WeatherBounds => _weatherBounds;
    public Vector3 BlendSize => _blendSize;
    public Vector3 VolumeSize => _volumeSize;
    public Vector3 Center => ((Component)this).transform.position;
    public Vector3 MinBounds => Center - VolumeSize / 2f;
    public Vector3 MaxBounds => Center + VolumeSize / 2f;
    public List<WeatherEffectController> EffectControllers => _effectControllers;
    public WeatherProfile WeatherProfile => _weatherProfile;
    protected Vector3 TopRightBlendCorner => ((Component)this).transform.position + ((Component)this).transform.right * (_blendSize.x / 2f) + ((Component)this).transform.forward * (_blendSize.z / 2f);
    protected Vector3 BottomRightBlendCorner => ((Component)this).transform.position + ((Component)this).transform.right * (_blendSize.x / 2f) - ((Component)this).transform.forward * (_blendSize.z / 2f);
    protected Vector3 TopLeftBlendCorner => ((Component)this).transform.position - ((Component)this).transform.right * (_blendSize.x / 2f) + ((Component)this).transform.forward * (_blendSize.z / 2f);
    protected Vector3 BottomLeftBlendCorner => ((Component)this).transform.position - ((Component)this).transform.right * (_blendSize.x / 2f) - ((Component)this).transform.forward * (_blendSize.z / 2f);

    [ObserversRpc(BufferLast = true, RunLocally = true)]
    public void Initialise(Vector3 weatherBounds, Vector3 volumeSize, Vector3 blendSize, float blendAmount, Vector3 anchorPosition, float heightMapWorldSize);
    private void Update();
    public void SetAnchor(Vector3 anchorPosition);
    public void SetNeighbourVolume(WeatherVolume neighbourVolume);
    public void BlendEffects(float blend, AnimationCurve blendCurve);
    public void SetShaderNumericParameter(string paramater, float value);
    public void SetShaderColorParameter(string paramater, Color value);
    public void SetVisualEffectNumericParameter(string paramater, float value);
    public void UpdateVolume(Vector3 playerPosition, float enclosureBlend);
    public bool IsInRightHalf(Vector3 point);
    public Vector2 GetClosestPointOnLeft(Vector3 point);
    public Vector2 GetClosestPointOnRight(Vector3 point);
    private void OnDrawGizmos();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    private void RpcWriter___Observers_Initialise_1999361799(Vector3 weatherBounds, Vector3 volumeSize, Vector3 blendSize, float blendAmount, Vector3 anchorPosition, float heightMapWorldSize);
    public void RpcLogic___Initialise_1999361799(Vector3 weatherBounds, Vector3 volumeSize, Vector3 blendSize, float blendAmount, Vector3 anchorPosition, float heightMapWorldSize);
    private void RpcReader___Observers_Initialise_1999361799(PooledReader PooledReader0, Channel channel);
    public override void Awake();
}