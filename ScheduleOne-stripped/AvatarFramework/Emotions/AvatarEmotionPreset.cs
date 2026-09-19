using System;
using ScheduleOne.Core.Avatar;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Emotions;
[Serializable]
public class AvatarEmotionPreset
{
    public string PresetName;
    public FaceAvatarObject FaceAvatarObject;
    public EyelidPosition LeftEyeRestingPosition;
    public EyelidPosition RightEyeRestingPosition;
    [Range(-30f, 30f)]
    public float BrowAngleChange_L;
    [Range(-30f, 30f)]
    public float BrowAngleChange_R;
    [Range(-1f, 1f)]
    public float BrowHeightChange_L;
    [Range(-1f, 1f)]
    public float BrowHeightChange_R;
    public static AvatarEmotionPreset Lerp(AvatarEmotionPreset start, AvatarEmotionPreset end, AvatarEmotionPreset neutralPreset, float lerp);
}