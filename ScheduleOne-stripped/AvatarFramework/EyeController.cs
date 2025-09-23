using System;
using System.Collections;
using EasyButtons;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.AvatarFramework;
[ExecuteInEditMode]
public class EyeController : MonoBehaviour
{
    private static float eyeHeightMultiplier;
    public bool DEBUG;
    [Header("References")]
    [SerializeField]
    public Eye leftEye;
    [SerializeField]
    public Eye rightEye;
    [Header("Location Settings")]
    [Range(0f, 45f)]
    [SerializeField]
    protected float eyeSpacing;
    [Range(-1f, 1f)]
    [SerializeField]
    protected float eyeHeight;
    [Range(0.5f, 1.5f)]
    [SerializeField]
    protected float eyeSize;
    [Header("Eyelid Settings")]
    [SerializeField]
    protected Color leftEyeLidColor;
    [SerializeField]
    protected Color rightEyeLidColor;
    public Eye.EyeLidConfiguration LeftRestingEyeState;
    public Eye.EyeLidConfiguration RightRestingEyeState;
    [Header("Eyeball Settings")]
    [SerializeField]
    protected Material eyeBallMaterial;
    [SerializeField]
    protected Color eyeBallColor;
    [Header("Pupil State")]
    [Range(0f, 1f)]
    public float PupilDilation;
    [Header("Blinking Settings")]
    public bool BlinkingEnabled;
    [SerializeField]
    [Range(0f, 10f)]
    protected float blinkInterval;
    [SerializeField]
    [Range(0f, 2f)]
    protected float blinkIntervalSpread;
    [SerializeField]
    [Range(0f, 1f)]
    protected float blinkDuration;
    private Avatar avatar;
    private Coroutine blinkRoutine;
    private float timeUntilNextBlink;
    private bool eyeBallTintOverridden;
    private bool eyeLidOverridden;
    private Eye.EyeLidConfiguration defaultLeftEyeRestingState;
    private Eye.EyeLidConfiguration defaultRightEyeRestingState;
    private float defaultDilation;
    public bool EyesOpen { get; protected set; } = true;

    protected virtual void Awake();
    protected void Update();
    private void OnEnable();
    [Button]
    public void ApplySettings();
    public void SetEyeballTint(Color col);
    public void OverrideEyeballTint(Color col);
    public void ResetEyeballTint();
    public void OverrideEyeLids(Eye.EyeLidConfiguration eyeLidConfiguration);
    public void ResetEyeLids();
    private void RagdollChange(bool oldValue, bool newValue, bool playStandUpAnim);
    public void SetEyesOpen(bool open);
    private void ApplyDilation();
    public void SetPupilDilation(float dilation, bool writeDefault = true);
    public void ResetPupilDilation();
    private void ApplyRestingEyeLidState();
    public void ForceBlink();
    public void SetLeftEyeRestingLidState(Eye.EyeLidConfiguration config);
    public void SetRightEyeRestingLidState(Eye.EyeLidConfiguration config);
    private IEnumerator BlinkRoutine();
    private void ResetBlinkCounter();
    public void LookAt(Vector3 position, bool instant = false);
}