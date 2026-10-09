using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.Core.Avatar;
using ScheduleOne.Map;
using ScheduleOne.NPCs;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers.Misc;
public class OrgyTent : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private NPCEnterableBuilding _building;
    [SerializeField]
    private Animation _animation;
    [Header("Settings")]
    [SerializeField]
    private Vector2 _minMaxtimeBetweenEffects;
    [Header("Audio")]
    [SerializeField]
    private AudioSourceController _audioSource;
    [SerializeField]
    private List<AudioClip> _femaleClips;
    [SerializeField]
    private List<AudioClip> _maleClips;
    private bool _isRunning;
    private float _timeUntilNextEffect;
    private void Start();
    private void Update();
    private void PlayEffect();
    private void CheckPlaying();
    private bool HasOccupantOfGender(EGender gender);
}