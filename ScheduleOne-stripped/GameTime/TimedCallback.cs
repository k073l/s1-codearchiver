using System;
using ScheduleOne.DevUtilities;

namespace ScheduleOne.GameTime;
public class TimedCallback
{
    private int _remainingMinutes;
    private Action _callback;
    public TimedCallback(Action callback, int durationMinutes, bool tickAtEndOfDay = true, bool tickOnTimeSkip = true);
    public void Cancel();
    private void OnTimeSkip(int skippedMinutes);
    private void Tick();
    private void Execute();
    private void Cleanup();
}