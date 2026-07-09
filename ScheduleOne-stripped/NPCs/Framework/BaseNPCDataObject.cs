using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
public abstract class BaseNPCDataObject : ScriptableObject
{
    public abstract void Initialize();
    public abstract NPCData GetRuntimeData();
    public abstract NPCData GetOriginalData();
}