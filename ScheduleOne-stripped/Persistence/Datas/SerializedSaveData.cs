using System;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class SerializedSaveData
{
    [NonSerialized]
    public static string _DataType;
    public string DataType;
    [NonSerialized]
    public static int _DataVersion;
    public int DataVersion;
    public string Version => Application.version;
}