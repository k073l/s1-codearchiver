using System;
using ScheduleOne.DevUtilities;

namespace ScheduleOne.Delivery;
[Serializable]
public class DeliveryReceipt
{
    public string StoreName;
    public string DestinationCode;
    public int LoadingDockIndex;
    public StringIntPair[] Items;
    public DeliveryReceipt(string storeName, string destinationCode, int loadingDockIndex, StringIntPair[] items);
    public DeliveryReceipt();
}