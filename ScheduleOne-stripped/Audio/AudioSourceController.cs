using System;
using System.Collections;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio;
[RequireComponent(typeof(AudioSource))]
public class AudioSourceController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private string _id;
    [SerializeField]
    [FormerlySerializedAs("AudioType")]
    private EAudioType _audioType;
    [Header("Volume")]
    [SerializeField]
    [FormerlySerializedAs("DefaultVolume")]
    [Range(0f, 1f)]
    private float _defaultBaseVolume;
    [SerializeField]
    [FormerlySerializedAs("VolumeMultiplier")]
    [Range(0f, 2f)]
    private float _volumeMultiplier;
    [Header("Pitch")]
    [SerializeField]
    [Range(0.1f, 3f)]
    private float _defaultBasePitch;
    [SerializeField]
    [FormerlySerializedAs("PitchMultiplier")]
    [Range(0f, 2f)]
    private float _pitchMultiplier;
    [SerializeField]
    [FormerlySerializedAs("RandomizePitch")]
    private bool _randomizePitch;
    [SerializeField]
    [FormerlySerializedAs("MinPitch")]
    [Conditional("_randomizePitch", false)]
    private float _minRandomPitch;
    [SerializeField]
    [FormerlySerializedAs("MaxPitch")]
    [Conditional("_randomizePitch", false)]
    private float _maxRandomPitch;
    [SerializeField]
    [FormerlySerializedAs("LowPassFilter")]
    [Conditional("_lowPassFilter", false)]
    private AudioLowPassFilter _lowPassFilter;
    protected AudioSource _audioSource;
    protected float _baseVolume;
    protected float _basePitch;
    public bool IsPlaying { get; }
    public float Time { get; }
    public AudioClip Clip { get; }
    public string Id => _id;
    public float VolumeMultiplier { get; set; }
    public float PitchMultiplier { get; set; }

    private void Awake();
    private void OnEnable();
    private void OnDisable();
    private void ApplyMixer();
    private void OnPause();
    private void OnUnpause();
    public void SetBaseVolume(float baseVolume);
    protected void ApplyVolume();
    public void SetBasePitch(float basePitch);
    private void ApplyPitch();
    public virtual void Play();
    public virtual void PlayOneShot();
    public void PlayOneShotDelayed(float delay);
    public void DuplicateAndPlayOneShot();
    public virtual void DuplicateAndPlayOneShot(Transform parent);
    protected void Delay(float delay, Action callback);
    protected IEnumerator DelayIE(float delay, Action callback);
    public void ApplyAudioSettings(AudioSettingsWrapper settings);
    public AudioSettingsWrapper ExtractAudioSettings();
    public void SetTime(float time);
    public void SetClip(AudioClip clip);
    public void SetLoop(bool loop);
    public void Stop();
}