using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using SFB;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public class PlayerLogExporter : MonoBehaviour
{
    private static void ExportPlayerLog();
    public static string FilterLog(string log);
    private static string ReadFileShared(string path);
    private static string GetLogPath();
}