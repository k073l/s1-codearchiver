namespace ScheduleOne.Core.Settings.Framework;
public interface ISerializable
{
    string Serialize();
    void Deserialize(string value);
}