using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Money;
using ScheduleOne.Product;
using ScheduleOne.Quests;
using ScheduleOne.UI.Phone.Messages;
using UnityEngine;

namespace ScheduleOne.Economy;
[Serializable]
public class DealGenerationEvent
{
    [Serializable]
    public class DayContainer
    {
        public EDay Day;
    }

    [Header("Settings")]
    public bool Enabled;
    public bool CanBeAccepted;
    public bool CanBeRejected;
    [Header("Timing Settings")]
    public List<DayContainer> ApplicableDays;
    public int GenerationTime;
    public int GenerationWindowDuration;
    [Header("Products and payment")]
    public ProductList ProductList;
    public float Payment;
    [Range(0f, 5f)]
    public float RelationshipRequirement;
    [Header("Messages")]
    [SerializeField]
    private MessageChain[] RequestMessageChains;
    public MessageChain[] ContractAcceptedResponses;
    public MessageChain[] ContractRejectedResponses;
    [Header("Location settings")]
    public DeliveryLocation DeliveryLocation;
    public int PickupScheduleGroup;
    [Header("Window/expiry settings")]
    public QuestWindowConfig DeliveryWindow;
    public bool Expires;
    [Tooltip("How many days after being accepted does this contract expire? Exact expiry is adjusted to match window end")]
    [Range(1f, 7f)]
    public int ExpiresAfter;
    public ContractInfo GenerateContractInfo(Customer customer);
    public bool ShouldGenerate(Customer customer);
    public MessageChain GetRandomRequestMessage();
    public MessageChain ProcessMessage(MessageChain messageChain);
    public MessageChain GetRejectionMessage();
    public MessageChain GetAcceptanceMessage();
    public string GetProductStringList();
    public string GetQualityString();
}