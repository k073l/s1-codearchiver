using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Audio;
public class AmbientOneShot : MonoBehaviour
{
    public enum EPlayTime
    {
        All,
        Day,
        Night
    }

    public AudioSourceController Audio;
    [Header("Settings")]
    [Range(0f, 1f)]
    public float Volume;
    [Range(0f, 1f)]
    public float ChancePerHour;
    public int CooldownTime;
    public EPlayTime PlayTime;
    public float MinDistance;
    public float MaxDistance;
    private int timeSinceLastPlay;
    private void Start();
    private void OnDrawGizmosSelected();
    private void MinPass();
    private void Play();
}