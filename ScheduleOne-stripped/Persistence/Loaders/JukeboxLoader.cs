using ScheduleOne.EntityFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class JukeboxLoader : GridItemLoader
{
    public override string ItemType => typeof(JukeboxData).Name;

    public override void Load(string mainPath);
    public override void Load(DynamicSaveData data);
}