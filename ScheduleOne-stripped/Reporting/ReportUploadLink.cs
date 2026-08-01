using System;

namespace ScheduleOne.Reporting;
[Serializable]
public class ReportUploadLink
{
    public string signedUrl;
    public string token;
    public string path;
    public string contentType;
}