using System;
using ScheduleOne.Dialogue;
using ScheduleOne.Economy;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class DealerNPCData : NPCData
{
    [Header("Dealer Data")]
    public EDealerType DealerType;
    public string HomeName;
    [Range(0f, 10000f)]
    public float SigningFee;
    [Range(0f, 1f)]
    public float SalesCutPercentage;
    public DialogueContainer RecruitDialogue;
    public DialogueContainer CollectCashDialogue;
    public DialogueContainer AssignCustomersDialogue;
    public override NPCData GetDeepCopy();
    private void PopulateDealerData(DealerNPCData data);
}