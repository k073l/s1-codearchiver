using System;
using System.Collections.Generic;
using ScheduleOne.Dialogue;
using ScheduleOne.Economy;
using ScheduleOne.GameTime;
using ScheduleOne.Money;
using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.Quests;
[Serializable]
public class ContractInfo
{
    public float Payment;
    public ProductList Products;
    public string DeliveryLocationGUID;
    public QuestWindowConfig DeliveryWindow;
    public bool Expires;
    public int ExpiresAfter;
    public int PickupScheduleIndex;
    public bool IsCounterOffer;
    public DeliveryLocation DeliveryLocation { get; private set; }

    public ContractInfo(float payment, ProductList products, string deliveryLocationGUID, QuestWindowConfig deliveryWindow, bool expires, int expiresAfter, int pickupScheduleIndex, bool isCounterOffer);
    public ContractInfo();
    public DialogueChain ProcessMessage(DialogueChain messageChain);
}