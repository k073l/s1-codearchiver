using System.Text;
using UnityEngine;

namespace ScheduleOne.Reporting;
public class DebugLogCollector : MonoBehaviour
{
    private const int LineLimit;
    private static StringBuilder log;
    private static int lineCount;
    public static string[] IgnoreList;
    public static string Log { get; }

    public void Awake();
    private unsafe void HandleLog(string logString, string stackTrace, LogType logType);
    private void CreateNewLog();
}