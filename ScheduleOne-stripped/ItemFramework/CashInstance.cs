using System;
using FishNet.Serializing;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Storage;
using UnityEngine;

namespace ScheduleOne.ItemFramework;
[Serializable]
public class CashInstance : StorableItemInstance
{
    public const float MAX_BALANCE;
    public float Balance { get; protected set; }

    public CashInstance(ItemDefinition definition, int quantity);
    public override ItemInstance GetCopy(int overrideQuantity = -1);
    public void ChangeBalance(float amount);
    public void SetBalance(float newBalance, bool blockClear = false);
    public override ItemData GetItemData();
    public override float GetMonetaryValue();
    public override void Write(Writer writer);
    public override void Read(Reader reader);
}