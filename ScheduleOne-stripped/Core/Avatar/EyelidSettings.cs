using System;
using UnityEngine;

namespace ScheduleOne.Core.Avatar;
[Serializable]
public struct EyelidSettings
{
    public Color EyelidTint;
    public float EyelidTintStrength;
    public EyelidPosition RestingState;
    public static EyelidSettings Default => new EyelidSettings(Color.white, 0f, EyelidPosition.Default);

    public EyelidSettings(Color eyelidTint, float eyelidTintStrength, EyelidPosition restingState);
    public EyelidSettings Clone();
}