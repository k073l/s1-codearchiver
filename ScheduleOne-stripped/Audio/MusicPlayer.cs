using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

namespace ScheduleOne.Audio;
public class MusicPlayer : PersistentSingleton<MusicPlayer>
{
    public static float TimeSinceLastAmbientTrack;
    public List<MusicTrack> Tracks;
    public AudioMixerGroup MusicMixer;
    public AudioMixerSnapshot DefaultSnapshot;
    public AudioMixerSnapshot DistortedSnapshot;
    private MusicTrack _currentTrack;
    public bool IsPlaying { get; }

    public void OnValidate();
    protected override void Start();
    private void Update();
    public void SetMusicDistorted(bool distorted, float transition = 5f);
    public void SetTrackEnabled(string trackName, bool enabled);
    public void StopTrack(string trackName);
    public void StopAndDisableTracks();
    private void UpdateTracks();
}