using System;
using UnityEngine;

namespace ScheduleOne.Audio;
[Serializable]
public class AudioSettingsWrapper
{
    public EAudioType AudioType;
    public float Volume;
    public float VolumeMultiplier;
    public Vector2 MinMaxPitch;
    public float PitchMultiplier;
    public bool RandomizePitch;
    [Range(10f, 22000f)]
    public int LowPassCutoffFrequency;
}