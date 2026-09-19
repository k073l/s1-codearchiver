using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;

namespace ScheduleOne.UI.SleepMessage;
public class SleepMessage : ISleepEvent
{
    private string _message;
    private float _duration;
    public bool IsInProgress { get; private set; }
    public int EventOrder { get; private set; } = 6;

    public SleepMessage(string message, float duration, int eventOrder);
    public void StartEvent();
}