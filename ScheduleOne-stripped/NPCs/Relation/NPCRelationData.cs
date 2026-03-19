using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.NPCs.Relation;
[Serializable]
public class NPCRelationData
{
    public enum EUnlockType
    {
        Recommendation,
        DirectApproach
    }

    public const float MinDelta;
    public const float MaxDelta;
    public const float DEFAULT_RELATION_DELTA;
    [SerializeField]
    protected List<NPC> FullGameConnections;
    [SerializeField]
    protected List<NPC> DemoConnections;
    public Action<float> onRelationshipChange;
    public Action<EUnlockType, bool> onUnlocked;
    public float RelationDelta { get; protected set; } = 2f;
    public float NormalizedRelationDelta => RelationDelta / 5f;
    public bool Unlocked { get; protected set; }
    public EUnlockType UnlockType { get; protected set; }
    public NPC NPC { get; protected set; }
    public List<NPC> Connections => FullGameConnections;

    public void SetNPC(NPC npc);
    public void Init(NPC npc);
    public virtual void ChangeRelationship(float deltaChange, bool network = true);
    public virtual void SetRelationship(float newDelta, bool network = true);
    public virtual void Unlock(EUnlockType type, bool notify = true);
    public virtual void UnlockConnections();
    public RelationshipData GetSaveData();
    public float GetAverageMutualRelationship();
    public bool IsKnown();
    public bool IsMutuallyKnown();
    public List<NPC> GetLockedConnections(bool excludeCustomers = false);
    public List<NPC> GetLockedDealers(bool excludeRecommended);
    public List<NPC> GetLockedSuppliers();
}