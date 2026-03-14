using FishNet;
using ScheduleOne.Core.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.NPCs.Other;
public class SmokeCigarette : MonoBehaviour
{
    [SerializeField]
    private EquippableData _cigarette;
    private NPC _npc;
    private IEquippedItemHandler _equippedItem;
    private void Awake();
    public void Begin();
    public void End();
}