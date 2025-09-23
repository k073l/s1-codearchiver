using System.IO;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Persistence.Loaders;
public class BrickPressLoader : GridItemLoader
{
    public override string ItemType => typeof(BrickPressData).Name;

    public override void Load(string mainPath);
    public override void Load(DynamicSaveData data);
}