using System;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.GameTime;
public class TimeUnityEvents : MonoBehaviour
{
    public UnityEvent onHourPass;
    public UnityEvent onDayPass;
    public UnityEvent onSleepStart;
    public UnityEvent onSleepEnd;
    private void Start();
    private void HourPass();
    private void DayPass();
    private void SleepStart();
    private void SleepEnd();
}