namespace ScheduleOne.Persistence;
public interface IBaseSaveable : ISaveable
{
    int LoadOrder { get; }
}