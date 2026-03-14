using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using SFB;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public static class PlayerLogExporter
{
    private static Action _onSuccess;
    private static Regex[] ExcludedRegexes;
    public static void ExportPlayerLog(bool previous, Action onSuccess = null);
    private static void SavePathSelected(string savePath, bool previous);
    public static string FilterLog(string log);
    private static string ReadFileShared(string path);
    public static string GetLogPath(bool previous);
}