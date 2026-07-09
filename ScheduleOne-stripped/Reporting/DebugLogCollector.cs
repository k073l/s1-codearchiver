using System.Text;
using UnityEngine;

namespace ScheduleOne.Reporting;
public class DebugLogCollector : MonoBehaviour
{
    private static StringBuilder log;
    public static string[] IgnoreList;
    public static string Log { get; }

    public void Awake();
    private unsafe void HandleLog(string logString, string stackTrace, LogType logType);
}