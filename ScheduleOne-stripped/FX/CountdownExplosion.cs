using System.Collections;
using FishNet;
using ScheduleOne.Audio;
using ScheduleOne.Combat;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.FX;
public class CountdownExplosion : MonoBehaviour
{
    public const float COUNTDOWN;
    public const float TICK_SPACING_MAX;
    public const float TICK_SPACING_MIN;
    public AudioSourceController TickSound;
    private Coroutine countdownRoutine;
    public void Trigger();
    public void StopCountdown();
}