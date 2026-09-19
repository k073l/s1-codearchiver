using System;
using UnityEngine;

namespace ScheduleOne.Core.Avatar;
[Serializable]
public struct EyebrowSettings
{
    public float Scale;
    public float Thickness;
    public float RestingHeight;
    public float RestingAngle;
    public Color Color;
    public static EyebrowSettings Default => new EyebrowSettings(1f, 1f, 0f, 0f, Color.black);

    public EyebrowSettings(float scale, float thickness, float restingHeight, float restingAngle, Color color);
    public EyebrowSettings Clone();
}