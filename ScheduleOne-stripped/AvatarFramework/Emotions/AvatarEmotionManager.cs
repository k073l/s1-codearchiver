using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Avatar;
using ScheduleOne.Core.Avatar;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Emotions;
public class AvatarEmotionManager : MonoBehaviour
{
    public const float MAX_UPDATE_DISTANCE_SQR;
    [Header("Settings")]
    public List<AvatarEmotionPreset> EmotionPresetList;
    [Header("References")]
    public Avatar Avatar;
    public EyeController EyeController;
    public EyebrowController EyebrowController;
    private EmotionOverride activeEmotionOverride;
    private List<EmotionOverride> overrideStack;
    private AvatarEmotionPreset neutralPreset;
    private Coroutine emotionLerpRoutine;
    private Dictionary<string, Coroutine> emotionRemovalRoutines;
    public string CurrentEmotion { get; protected set; } = "Neutral";
    public AvatarEmotionPreset CurrentEmotionPreset { get; protected set; }
    public bool IsSwitchingEmotion => emotionLerpRoutine != null;

    public event Action<AvatarEmotionPreset> OnEmotionChanged;
    public event Action<FaceAvatarObject> OnFaceChanged;
    private void Start();
    public void UpdateEmotion();
    public void ConfigureNeutralFace(Texture2D faceTex, float restingBrowHeight, float restingBrowAngle, Eye.EyeLidConfiguration leftEyelidConfig, Eye.EyeLidConfiguration rightEyelidConfig);
    public void SetNeutralFace(string faceId);
    public void SetNeutralEyes(EyeSettings leftEye, EyeSettings rightEye, EyebrowSettings leftEyebrow, EyebrowSettings rightEyebrow, EyelidPosition leftEyelidPosition, EyelidPosition rightEyelidPosition);
    public virtual void AddEmotionOverride(string emotionName, string overrideLabel, float duration = 0f, int priority = 0);
    public void RemoveEmotionOverride(string label);
    public void ClearOverrides();
    private void ClearRemovalRoutine(string label);
    public EmotionOverride GetHighestPriorityOverride();
    private void LerpEmotion(AvatarEmotionPreset preset, float animationTime = 0.2f);
    private void SetEmotion(AvatarEmotionPreset preset);
    public bool HasEmotion(string emotion);
    public AvatarEmotionPreset GetEmotion(string emotion);
}