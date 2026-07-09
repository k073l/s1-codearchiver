using System;

namespace ScheduleOne.Reporting;
[Serializable]
public class ReportSubmissionResponse
{
    public bool success;
    public ReportResponseData data;
    public string error;
}