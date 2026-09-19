namespace ScheduleOne.GameTime;
public interface ISleepEvent
{
    bool IsInProgress { get; }

    int EventOrder { get; }

    void StartEvent();
}