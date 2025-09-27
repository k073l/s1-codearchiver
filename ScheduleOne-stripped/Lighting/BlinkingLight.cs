using System.Collections;
using ScheduleOne.Misc;
using UnityEngine;

namespace ScheduleOne.Lighting;
[RequireComponent(typeof(ToggleableLight))]
public class BlinkingLight : MonoBehaviour
{
    public bool IsOn;
    public float OnTime;
    public float OffTime;
    private ToggleableLight light;
    private Coroutine blinkRoutine;
    private void Awake();
    private void Update();
    private IEnumerator Blink();
}