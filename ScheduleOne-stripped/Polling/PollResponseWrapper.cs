using System;

namespace ScheduleOne.Polling;
[Serializable]
public class PollResponseWrapper
{
    public bool success;
    public PollResponse data;
}