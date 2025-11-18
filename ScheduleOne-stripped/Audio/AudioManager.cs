using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace ScheduleOne.Audio;
public class AudioManager : PersistentSingleton<AudioManager>
{
    private const float MinWorldMusicVolumeMulitplier;
    private const float MusicFadeTime;
    private const float MinGameVolume;
    private const float MaxGameVolume;
    private const float GameVolumeLerpSpeed;
    [Range(0f, 2f)]
    [SerializeField]
    protected float masterVolume;
    [Range(0f, 2f)]
    [SerializeField]
    protected float ambientVolume;
    [Range(0f, 2f)]
    [SerializeField]
    protected float footstepsVolume;
    [Range(0f, 2f)]
    [SerializeField]
    protected float fxVolume;
    [Range(0f, 2f)]
    [SerializeField]
    protected float uiVolume;
    [Range(0f, 2f)]
    [SerializeField]
    protected float musicVolume;
    [Range(0f, 2f)]
    [SerializeField]
    protected float voiceVolume;
    public UnityEvent onSettingsChanged;
    [Header("Generic Door Sounds")]
    public AudioSourceController DoorOpen;
    public AudioSourceController DoorClose;
    [Header("Mixers")]
    public AudioMixerGroup MainGameMixer;
    public AudioMixerGroup MenuMixer;
    public AudioMixerGroup MusicMixer;
    private float currentGameVolume;
    public AudioMixerSnapshot DefaultSnapshot;
    public AudioMixerSnapshot DistortedSnapshot;
    public float MasterVolume => masterVolume;
    public float AmbientVolume => ambientVolume * masterVolume;
    public float UnscaledAmbientVolume => ambientVolume;
    public float FootstepsVolume => footstepsVolume * masterVolume;
    public float UnscaledFootstepsVolume => footstepsVolume;
    public float FXVolume => fxVolume * masterVolume;
    public float UnscaledFXVolume => fxVolume;
    public float UIVolume => uiVolume * masterVolume;
    public float UnscaledUIVolume => uiVolume;
    public float MusicVolume => musicVolume * masterVolume * 0.7f;
    public float UnscaledMusicVolume => musicVolume;
    public float VoiceVolume => voiceVolume * masterVolume * 0.5f;
    public float UnscaledVoiceVolume => voiceVolume;
    public float WorldMusicVolumeMultiplier { get; private set; } = 1f;

    public float GetScaledMusicVolumeMultiplier(float min);
    protected override void Awake();
    protected override void Start();
    protected void Update();
    public void SetDistorted(bool distorted, float transition = 5f);
    private void SetGameVolume(float value);
    private float ValueToVolume(float value);
    public float GetVolume(EAudioType audioType, bool scaled = true);
    public void SetMasterVolume(float volume);
    public void SetVolume(EAudioType type, float volume);
}