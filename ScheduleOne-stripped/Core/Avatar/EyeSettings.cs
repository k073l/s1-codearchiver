using System;
using UnityEngine;

namespace ScheduleOne.Core.Avatar;
[Serializable]
public struct EyeSettings
{
    public Color EyeballColor;
    public float PupilDilation;
    public static EyeSettings Default => new EyeSettings(Color.white, 0.65f);

    public EyeSettings(Color eyeballColor, float pupilDilation);
    public EyeSettings Clone();
}