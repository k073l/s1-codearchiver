using System;
using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.GameTime;
[Serializable]
public struct GameDateTime
{
    public int elapsedDays;
    public int time;
    public GameDateTime(int _elapsedDays, int _time);
    public GameDateTime(int _minSum);
    public GameDateTime(GameDateTimeData data);
    public int GetMinSum();
    public GameDateTime AddMins(int mins);
    public GameDateTime GetCopy();
    public static GameDateTime operator +(GameDateTime a, GameDateTime b)
    {
        return new GameDateTime(a.GetMinSum() + b.GetMinSum());
    }

    public static GameDateTime operator -(GameDateTime a, GameDateTime b)
    {
        return new GameDateTime(a.GetMinSum() - b.GetMinSum());
    }

    public static bool operator>(GameDateTime a, GameDateTime b)
    {
        return a.GetMinSum() > b.GetMinSum();
    }

    public static bool operator <(GameDateTime a, GameDateTime b)
    {
        return a.GetMinSum() < b.GetMinSum();
    }
}