using System;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class SaveData
{
    public string DataType;
    public int DataVersion;
    public string GameVersion;
    public SaveData();
    protected virtual int GetDataVersion();
    public virtual string GetJson(bool prettyPrint = true);
}