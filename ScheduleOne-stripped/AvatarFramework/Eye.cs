using System;
using System.Collections;
using ScheduleOne.Core.Avatar;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.AvatarFramework;
public class Eye : MonoBehaviour
{
    [Serializable]
    public struct EyeLidConfiguration
    {
        [Range(0f, 1f)]
        public float topLidOpen;
        [Range(0f, 1f)]
        public float bottomLidOpen;
        public static EyeLidConfiguration Default => new EyeLidConfiguration(0.5f, 0.4f);

        public EyeLidConfiguration(float topLidOpen, float bottomLidOpen);
        public override string ToString();
        public static EyeLidConfiguration Lerp(EyeLidConfiguration start, EyeLidConfiguration end, float lerp);
    }

    public const float DefaultEyeballEmission;
    private const float PupilLookSpeed;
    private static Vector3 MaxRotation;
    private static Vector3 MinRotation;
    [Header("Settings")]
    [SerializeField]
    [FormerlySerializedAs("AngleOffset")]
    private Vector2 _defaultPupilAngleOffset;
    [SerializeField]
    private Material _defaultEyeballMaterial;
    [Header("References")]
    [SerializeField]
    private Transform _container;
    [SerializeField]
    private Transform _topLidContainer;
    [SerializeField]
    private Transform _bottomLidContainer;
    [SerializeField]
    private Transform _pupilContainer;
    [SerializeField]
    private MeshRenderer _topLidRenderer;
    [SerializeField]
    private MeshRenderer _bottomLidRenderer;
    [SerializeField]
    private MeshRenderer _eyeballRenderer;
    [SerializeField]
    [FormerlySerializedAs("LookOrigin")]
    private Transform _lookOrigin;
    [SerializeField]
    private OptimizedLight _light;
    [SerializeField]
    private SkinnedMeshRenderer _pupilRenderer;
    private EyelidPosition _eyelidRestingPosition;
    private EyelidPosition _defaultEyelidRestingPosition;
    private EyelidPosition _currentEyelidPosition;
    private Coroutine _blinkRoutine;
    private Coroutine _setStateRoutine;
    private Color _defaultEyeballColor;
    private float _defaultEyeballEmission;
    private float _defaultPupilDilation;
    private Vector2 _currentPupilOffset;
    private Color _eyeballColor;
    private float _eyeballEmission;
    private Color _lidBaseColor;
    private Color _lidTintColor;
    private float _lidTintStrength;
    private bool _isBlinking => _blinkRoutine != null;

    private void Awake();
    private void OnEnable();
    private void OnDisable();
    public void SetEyeballColor(Color color, float emission = 0.115f, bool setDefault = true);
    public void ResetEyeballColor();
    public void SetEyeballMaterial(Material mat);
    public void ResetEyeballMaterial();
    public void SetEyelidColor(Color color);
    public void SetEyelidRestingState(EyelidPosition restingState, bool setDefault);
    public void ResetEyelidRestingState();
    public void SetEyelidTint(Color color, float strength);
    public void SetDilation(float dilation, bool setDefault = true);
    public void ResetDilation();
    public void SetPupilOffset(Vector2 offset, bool setDefault = true);
    public void ResetPupilOffset();
    public void SetPupilEnabled(bool enabled);
    public void SetEyeLight(Color color, float intensity);
    public void LookAt(Vector3 position);
    public void Blink(float blinkDuration);
    private void ApplyEyeballColor();
    private void ApplyEyelidColor();
    private void SetEyelidPosition(EyelidPosition _eyelidPosition);
    private void StopEyeCoroutines();
}