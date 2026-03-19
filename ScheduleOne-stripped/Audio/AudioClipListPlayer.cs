using System;
using System.Collections.Generic;
using GameKit.Utilities;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio;
[RequireComponent(typeof(AudioSourceController))]
public class AudioClipListPlayer : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("Clips")]
    private List<AudioClip> _clips;
    [SerializeField]
    private bool _shuffleOnAwake;
    private AudioSourceController _audioSource;
    private int _currentClipIndex;
    private void Awake();
    private void Start();
    private void OnDestroy();
    private void OnTick();
}