using System;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class LegacyNPCLoader : Loader
{
    public virtual string NPCType => typeof(NPCData).Name;

    public LegacyNPCLoader();
    public override void Load(string mainPath);
    protected void TryLoadInventory(string mainPath, NPC npc);
}