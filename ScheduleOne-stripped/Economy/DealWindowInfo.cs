namespace ScheduleOne.Economy;
public struct DealWindowInfo
{
    public const int WINDOW_DURATION_MINS;
    public const int WINDOW_COUNT;
    public int StartTime;
    public int EndTime;
    public static readonly DealWindowInfo Morning;
    public static readonly DealWindowInfo Afternoon;
    public static readonly DealWindowInfo Night;
    public static readonly DealWindowInfo LateNight;
    public DealWindowInfo(int startTime, int endTime);
    public static DealWindowInfo GetWindowInfo(EDealWindow window);
    public static EDealWindow GetWindow(int time);
}