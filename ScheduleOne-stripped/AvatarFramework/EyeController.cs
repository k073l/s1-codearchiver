using System;
using System.Collections;
using ScheduleOne.Core.Avatar;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.AvatarFramework;
public class EyeController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Eye _leftEye;
    [SerializeField]
    private Eye _rightEye;
    [Header("Blinking Settings")]
    [SerializeField]
    [FormerlySerializedAs("BlinkingEnabled")]
    private bool blinkingEnabled;
    [SerializeField]
    [Range(0f, 10f)]
    private float blinkInterval;
    [SerializeField]
    [Range(0f, 2f)]
    private float blinkIntervalSpread;
    [SerializeField]
    [Range(0f, 1f)]
    private float blinkDuration;
    private Coroutine _blinkRoutine;
    private float _timeUntilNextBlink;
    public Eye LeftEye => _leftEye;
    public Eye RightEye => _rightEye;

    protected virtual void Awake();
    private void OnDisable();
    protected void Update();
    public void LookAt(Vector3 position);
    public void ApplyEyeSettings(EyeSettings leftEyeSettings, EyeSettings rightEyeSettings);
    public void ApplyEyelidSettings(EyelidSettings leftEyelidSettings, EyelidSettings rightEyelidSettings);
    public void SetEyelidColor(Color eyelidColor);
    public void SetEyelidRestingPosition(EyelidPosition position);
    public void SetEyelidRestingPosition(EAvatarSide side, EyelidPosition position);
    public void ResetEyelidRestingPosition();
    public void ResetEyelidRestingPosition(EAvatarSide side);
    public void SetEyeballColor(Color color, float emission = 0.115f, bool setDefault = false);
    public void SetEyeballColor(EAvatarSide side, Color color, float emission = 0.115f, bool setDefault = false);
    public void ResetEyeballColor();
    public void ResetEyeballColor(EAvatarSide side);
    public void SetPupilDilation(float dilation, bool setDefault = true);
    public void SetPupilDilation(EAvatarSide side, float dilation, bool setDefault = true);
    public void ResetPupilDilation();
    public void ResetPupilDilation(EAvatarSide side);
    public void SetEyeLight(Color color, float intensity);
    public void SetEyeLight(EAvatarSide side, Color color, float intensity);
    public void ResetEyeLight();
    public void ResetEyeLight(EAvatarSide side);
    private void OnRagdollChange(bool ragdoll);
    public void SetEyeballMaterial(Material material);
    public void ResetEyeballMaterial();
    public void Blink();
    private void ResetBlinkCounter();
    private IEnumerator BlinkControlRoutine();
}