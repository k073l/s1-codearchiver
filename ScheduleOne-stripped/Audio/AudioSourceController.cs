using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace ScheduleOne.Audio;
[RequireComponent(typeof(AudioSource))]
public class AudioSourceController : MonoBehaviour
{
    public bool DEBUG;
    public AudioSource AudioSource;
    [Header("Settings")]
    public EAudioType AudioType;
    [Range(0f, 1f)]
    public float DefaultVolume;
    public bool RandomizePitch;
    public float MinPitch;
    public float MaxPitch;
    [Range(0f, 2f)]
    [SerializeField]
    private float VolumeMultiplier;
    [Range(0f, 2f)]
    [SerializeField]
    private float PitchMultiplier;
    private float basePitch;
    public float Volume { get; protected set; } = 1f;
    public bool isPlaying => AudioSource.isPlaying;
    public float volumeMultiplier { get; set; }
    public float pitchMultiplier { get; set; }

    private void Awake();
    private IEnumerator Start();
    private void DoPauseStuff();
    private void OnDestroy();
    private void OnValidate();
    private void Pause();
    private void Unpause();
    public void SetVolume(float volume);
    public void ApplyVolume();
    public void ApplyPitch();
    public virtual void Play();
    public virtual void PlayOneShot(bool duplicateAudioSource = false);
    public void Stop();
}