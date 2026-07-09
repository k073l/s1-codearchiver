using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
public abstract class GenericNPCDataObject<T> : BaseNPCDataObject where T : NPCData
{
    [SerializeField]
    protected T _data;
    public override NPCData GetRuntimeData();
    public override NPCData GetOriginalData();
}