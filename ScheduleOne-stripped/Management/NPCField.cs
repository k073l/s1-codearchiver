using System;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class NPCField : ConfigField
{
    public Type TypeRequirement;
    public UnityEvent<NPC> onNPCChanged;
    public NPC SelectedNPC { get; protected set; }

    public NPCField(EntityConfiguration parentConfig);
    public void SetNPC(NPC npc, bool network);
    public bool DoesNPCMatchRequirement(NPC npc);
    public override bool IsValueDefault();
    public NPCFieldData GetData();
    public void Load(NPCFieldData data);
}