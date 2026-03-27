using System;
using ScheduleOne.DevUtilities;

namespace ScheduleOne.GameTime;
public class TimedCallback
{
    private int _remainingMinutes;
    private Action _callback;
    private int _initialRemainingMinutes;
    public TimedCallback(Action callback, int durationMinutes, bool tickAtEndOfDay = true, bool tickOnTimeSkip = true);
    public void Cancel();
    public void Reset();
    private void OnTimeSkip(int skippedMinutes);
    private void Tick();
    private void Execute();
    private void Cleanup();
}