using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio;
public class MusicManager : PersistentSingleton<MusicManager>
{
    private const float TrackUpdateInterval;
    [SerializeField]
    [FormerlySerializedAs("DefaultSnapshot")]
    private AudioMixerSnapshot _defaultSnapshot;
    [SerializeField]
    [FormerlySerializedAs("DistortedSnapshot")]
    private AudioMixerSnapshot _distortedSnapshot;
    private List<MusicTrack> _tracks;
    private MusicTrack _currentTrack;
    public bool IsAnyTrackPlaying { get; }

    protected override void Awake();
    protected override void Start();
    public void SetMusicDistorted(bool distorted, float transition = 5f);
    public void SetTrackEnabled(string trackName, bool enabled);
    public bool TryGetTrack(string trackName, out MusicTrack track);
    public void StopTrack(string trackName);
    public void StopAndDisableTracks();
    private void UpdateTracks();
}