using System;
using System.Collections.Generic;

namespace ScheduleOne.Reporting;
[Serializable]
public class ReportResponseData
{
    public string reportUid;
    public Dictionary<string, ReportUploadLink> uploadLinks;
}