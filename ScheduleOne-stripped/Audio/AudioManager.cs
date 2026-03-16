using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

namespace ScheduleOne.Audio;
public class AudioManager : PersistentSingleton<AudioManager>
{
    private const float MinGameVolume;
    private const float MaxGameVolume;
    private const float GameVolumeLerpSpeed;
    public Action onVolumeSettingsChanged;
    [SerializeField]
    private AudioMixerSnapshot _defaultSnapshot;
    [SerializeField]
    private AudioMixerSnapshot _distortedSnapshot;
    private float _masterVolume;
    private float _ambientVolume;
    private float _footstepsVolume;
    private float _fxVolume;
    private float _uiVolume;
    private float _musicVolume;
    private float _voiceVolume;
    private float _weatherVolume;
    private float _currentMainMixerVolume;
    public float MasterVolume => _masterVolume;

    [field: SerializeField]
    public AudioMixerGroup MainGameMixer { get; private set; }

    [field: SerializeField]
    public AudioMixerGroup MenuMixer { get; private set; }

    [field: SerializeField]
    public AudioMixerGroup MusicMixer { get; private set; }

    protected override void Awake();
    protected override void Start();
    private void Update();
    public void SetDistorted(bool distorted, float transition = 5f);
    public float GetVolume(EAudioType audioType, bool scaled = true);
    public void SetMasterVolume(float volume);
    public void SetVolume(EAudioType type, float volume);
    private void SetMainMixerVolume(float value);
    private static float ValueToVolume(float value);
}