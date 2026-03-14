using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio;
public class AudioZone : PolygonalZone
{
    private const float VolumeChangeRate;
    private const float UpdateInterval;
    [Range(1f, 200f)]
    [FormerlySerializedAs("MaxDistance")]
    [SerializeField]
    private float _maximumAudibleDistance;
    [SerializeField]
    [FormerlySerializedAs("Tracks")]
    private List<AudioZoneTrack> _tracks;
    private float _localCameraDistance;
    private float _currentVolume;
    private List<IAudioZoneModifier> _modifiers;
    protected override void Awake();
    private void Start();
    private void OnUncappedMinPass();
    private void Update();
    private float GetModifierMultiplier();
    private void RecalculateCameraDistance();
    public void AddModifier(IAudioZoneModifier modifier);
    public void RemoveModifier(IAudioZoneModifier modifier);
    private float GetFalloffFactor(float distance);
}