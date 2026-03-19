using System.Collections.Generic;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.ObjectScripts;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio;
public class AmbientTrackGroup : MonoBehaviour
{
    private const float AmbientTrackCooldown;
    private static float TimeOnLastAmbientTrackStart;
    private static AmbientTrackGroup LastPlayedTrackGroup;
    private static bool IsAnyTrackGroupQueued;
    [SerializeField]
    [FormerlySerializedAs("Tracks")]
    private List<MusicTrack> _trackList;
    [SerializeField]
    [FormerlySerializedAs("MinTime")]
    private int _windowStartTime;
    [SerializeField]
    [FormerlySerializedAs("MaxTime")]
    private int _windowEndTime;
    [SerializeField]
    [FormerlySerializedAs("Chance")]
    [Range(0f, 1f)]
    private float _chanceToPlay;
    private int _startTime;
    private bool _playTrack;
    private bool _trackRandomized;
    private void Awake();
    [Button]
    public void ForcePlay();
    public void Stop();
    private void Update();
    protected virtual bool CanPlayNow();
}