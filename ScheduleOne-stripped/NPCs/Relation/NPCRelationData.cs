using System;
using System.Collections.Generic;
using ScheduleOne.Economy;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.NPCs.Relation;
[Serializable]
public class NPCRelationData
{
    public enum EUnlockType
    {
        Recommendation,
        DirectApproach
    }

    public const float MinRelationship;
    public const float MaxRelationship;
    [FormerlySerializedAs("FullGameConnections")]
    public List<NPC> Connections;
    public float RelationDelta { get; protected set; }
    public float NormalizedRelationDelta => RelationDelta / 5f;
    public bool Unlocked { get; protected set; }
    public EUnlockType UnlockType { get; protected set; }
    public NPC NPC { get; protected set; }

    public event Action<float> OnRelationshipChange;
    public event Action<EUnlockType, bool> OnUnlocked;
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