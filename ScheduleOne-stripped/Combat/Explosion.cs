using System.Collections.Generic;
using FishNet;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Noise;
using UnityEngine;

namespace ScheduleOne.Combat;
public class Explosion : MonoBehaviour
{
    public AudioSourceController Sound;
    public unsafe void Initialize(Vector3 origin, ExplosionData data);
}