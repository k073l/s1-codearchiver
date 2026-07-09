namespace ScheduleOne.Core;
public interface IValueProvider<T>
{
    T GetValue();
}