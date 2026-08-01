using System;
using System.Collections.Generic;

namespace ScheduleOne.Reporting;
[Serializable]
public class ReportSubmission
{
    public string ticket;
    public string title;
    public string description;
    public ReportTag[] tags;
    public Dictionary<string, string> metadata;
}