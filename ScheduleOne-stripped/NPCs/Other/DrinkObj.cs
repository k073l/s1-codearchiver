using System;
using System.Collections.Generic;
using FishNet;
using ScheduleOne.Core.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.NPCs.Other;
public class DrinkObj : MonoBehaviour
{
    [Serializable]
    public class DrinkData
    {
        public EquippableData Item;
        public float AlcoholContent;
    }

    [SerializeField]
    private List<DrinkData> _drinks;
    private NPC _npc;
    private IEquippedItemHandler _equippedItem;
    private int _currentDrink;
    private void Awake();
    public void SetDrink(int index);
    public void Begin();
    public void End();
}