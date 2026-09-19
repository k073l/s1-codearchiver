using System;
using System.Collections.Generic;
using ScheduleOne.Effects;
using ScheduleOne.Levelling;
using ScheduleOne.NPCs.Framework;
using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers;
[CreateAssetMenu(fileName = "SpecialCustomerData", menuName = "ScheduleOne/NPCs/Special Customer Data", order = 1)]
public class SpecialCustomerData : ScriptableObject
{
    [Serializable]
    public class NPCContainer
    {
        public BaseNPCDataObject Data;
    }

    [Header("General")]
    [SerializeField]
    protected string _groupName;
    [SerializeField]
    protected string _groupId;
    [TextArea]
    public string GroupDescription;
    [TextArea]
    [SerializeField]
    private string ArrivalMessage;
    [TextArea]
    [SerializeField]
    private string IncomingMessage;
    public Color GroupUIColor;
    [Header("Buy Quantity")]
    [Tooltip("Buy quantity at the lowest player level")]
    [SerializeField]
    private int BaseBuyQuantity;
    [Tooltip("Additional buy quantity per player rank (e.g. StreetRat -> Hoodlum)")]
    [SerializeField]
    private int AdditionalBuyQuantityPerRank;
    [Tooltip("Maximum buy quantity regardless of player rank")]
    [SerializeField]
    private int MaxBuyQuantity;
    [Header("Drugs & Effects")]
    [Tooltip("The type of drug this special customer group prefers")]
    public List<EDrugType> DrugPreference;
    [Tooltip("Effects that will be randomly selected from when generating a special customer from this group.")]
    public List<Effect> Effects;
    [Header("Leader")]
    public NPCContainer Leader;
    [Header("Group")]
    public List<NPCContainer> Customers;
    [Header("Camp")]
    public SpecialCustomerCamp CampPrefab;
    [Header("Audio")]
    public AudioClip DealCompleteClip;
    [Range(0f, 1f)]
    public float DealCompleteClipVolume;
    [Tooltip("How many seconds to delay playing the deal complete clip after the deal completion popup is shown.")]
    [Range(0f, 1f)]
    public float DealCompleteClipDelay;
    public string GroupName => _groupName;
    public string GroupId => _groupId;

    public string GetArrivalMessage(bool applyColor = true);
    public string GetIncomingMessage(bool applyColor = true);
    public int GetBuyQuantityForPlayerRank(ERank rank);
}