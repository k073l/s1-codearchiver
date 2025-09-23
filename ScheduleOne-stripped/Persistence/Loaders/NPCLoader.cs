using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class NPCLoader : DynamicLoader
{
    public virtual string NPCType => typeof(NPCData).Name;

    public NPCLoader();
    public override void Load(DynamicSaveData saveData);
}