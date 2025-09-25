using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Audio;
public class AudioZone : Zone
{
    [Serializable]
    public class Track
    {
        public AudioSourceController Source;
        [Range(0.01f, 2f)]
        public float Volume;
        public int StartTime;
        public int EndTime;
        public int FadeTime;
        private float timeVolMultiplier;
        private int fadeInStart;
        private int fadeInEnd;
        private int fadeOutStart;
        private int fadeOutEnd;
        private int fadeInStartMinSum;
        private int fadeInEndMinSum;
        private int fadeOutStartMinSum;
        private int fadeOutEndMinSum;
        public void Init();
        public void Update(float multiplier);
        public void UpdateTimeMultiplier(int time);
    }

    public const float VOLUME_CHANGE_RATE;
    public const float ROLLOFF_SCALE;
    [Header("Settings")]
    [Range(1f, 200f)]
    public float MaxDistance;
    public List<Track> Tracks;
    public Dictionary<AudioZoneModifierVolume, float> Modifiers;
    protected float CurrentVolumeMultiplier;
    public float LocalPlayerDistance { get; protected set; }
    public float VolumeModifier { get; set; }

    protected override void Awake();
    private void Start();
    public void Recalculate();
    private void Update();
    private float GetTotalVolumeMultiplier();
    private void MinPass();
    public void AddModifier(AudioZoneModifierVolume modifier, float value);
    public void RemoveModifier(AudioZoneModifierVolume modifier);
    private float GetFalloffFactor(float distance);
}