using System;
using ScheduleOne.UI.Phone;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class SupplierNPCData : NPCData
{
    [Header("Supplier Data")]
    public float MinimumDeaddropOrderLimit;
    public float MaximumDeaddropOrderLimit;
    public PhoneShopInterface.Listing[] DeliveryShopListings;
    [TextArea(3, 10)]
    public string SupplierRecommendMessage;
    [TextArea(3, 10)]
    public string SupplierUnlockHint;
    public override NPCData GetDeepCopy();
    private void PopulateSupplierData(SupplierNPCData data);
}