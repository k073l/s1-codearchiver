using System;
using UnityEngine;

namespace ScheduleOne.Core.Audio;
[Serializable]
public class AudioSettingsWrapper
{
    public AudioClip Clip;
    public EAudioType AudioType;
    public float Volume;
    public float VolumeMultiplier;
    [Range(-1f, 1f)]
    public float PanStereo;
    public Vector2 MinMaxPitch;
    public float PitchMultiplier;
    public bool RandomizePitch;
    [Range(10f, 22000f)]
    public int LowPassCutoffFrequency;
}