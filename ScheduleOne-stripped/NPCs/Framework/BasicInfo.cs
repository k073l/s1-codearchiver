using System;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class BasicInfo
{
    public string FirstName;
    public bool HasLastName;
    public string LastName;
    public string ID;
    public BasicInfo GetCopy();
}