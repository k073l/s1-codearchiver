using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio;
public class AudioZoneModifierVolume : MonoBehaviour, IAudioZoneModifier
{
    [FormerlySerializedAs("Zones")]
    [SerializeField]
    private List<AudioZone> _zones;
    [FormerlySerializedAs("VolumeMultiplier")]
    [SerializeField]
    private float _volumeMultiplier;
    private BoxCollider[] _colliders;
    public float VolumeMultiplier => _volumeMultiplier;

    private void Start();
    private void Refresh();
    private bool IsCameraWithinVolume();
}