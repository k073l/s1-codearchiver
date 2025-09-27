using System;
using FishNet.Serializing.Helping;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Property;
using ScheduleOne.UI.Phone.Delivery;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Delivery;
[Serializable]
public class DeliveryInstance
{
    public string DeliveryID;
    public string StoreName;
    public string DestinationCode;
    public int LoadingDockIndex;
    public StringIntPair[] Items;
    public EDeliveryStatus Status;
    public int TimeUntilArrival;
    [NonSerialized]
    [CodegenExclude]
    public UnityEvent onDeliveryCompleted;
    [CodegenExclude]
    public DeliveryVehicle ActiveVehicle { get; private set; }

    [CodegenExclude]
    public ScheduleOne.Property.Property Destination => Singleton<PropertyManager>.Instance.GetProperty(DestinationCode);

    [CodegenExclude]
    public LoadingDock LoadingDock => Destination.LoadingDocks[LoadingDockIndex];

    public DeliveryInstance(string deliveryID, string storeName, string destinationCode, int loadingDockIndex, StringIntPair[] items, EDeliveryStatus status, int timeUntilArrival);
    public DeliveryInstance();
    public int GetTimeStatus();
    public void SetStatus(EDeliveryStatus status);
    public void AddItemsToDeliveryVehicle();
    public void OnMinPass();
}