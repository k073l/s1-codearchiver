using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Map;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio;
[RequireComponent(typeof(AudioSourceController))]
public class AmbientOneShot : MonoBehaviour
{
    private enum EPlayTime
    {
        All,
        Day,
        Night
    }

    [Header("Settings")]
    [SerializeField]
    [FormerlySerializedAs("Volume")]
    [Range(0f, 1f)]
    private float _volume;
    [SerializeField]
    [FormerlySerializedAs("ChancePerHour")]
    [Range(0f, 1f)]
    private float _playChancePerHour;
    [SerializeField]
    [FormerlySerializedAs("CooldownTime")]
    private int _cooldownTime;
    [SerializeField]
    [FormerlySerializedAs("PlayTime")]
    private EPlayTime _playTime;
    [SerializeField]
    [FormerlySerializedAs("MinDistance")]
    private float _minDistanceFromCameraToPlay;
    [SerializeField]
    [FormerlySerializedAs("MaxDistance")]
    private float _maxDistanceFromCameraToPlay;
    [SerializeField]
    [FormerlySerializedAs("PlayWhileInSewer")]
    private bool _canPlayWhilePlayerInSewer;
    private int _timeSinceLastPlay;
    private AudioSourceController _audioSource;
    private void Awake();
    private void Start();
    private void OnUncappedMinPass();
    private void Play();
}