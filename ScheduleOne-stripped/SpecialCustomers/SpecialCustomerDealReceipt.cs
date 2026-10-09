using System;
using System.Collections.Generic;
using ScheduleOne.ItemFramework;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;

namespace ScheduleOne.SpecialCustomers;
[Serializable]
public class SpecialCustomerDealReceipt
{
    public Player Seller;
    public SpecialCustomerLeader Leader;
    public List<ItemInstance> Items;
    public int BasePayment;
    public int DesiredEffectsBonusPayment;
    public int GetTotalPayment();
}