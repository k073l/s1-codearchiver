using System;

namespace ScheduleOne.Reporting;
[Serializable]
public class ReportTag
{
    public string name;
    public string category;
    public ReportTag(string category, string name);
}