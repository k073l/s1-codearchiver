using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Audio;
public class AudioZoneModifierVolume : MonoBehaviour
{
    public List<AudioZone> Zones;
    public float VolumeMultiplier;
    private BoxCollider[] colliders;
    private void Start();
    private void Refresh();
}