using ScheduleOne.Core.Settings.Framework;
using UnityEngine;

namespace ScheduleOne.Core.Deliveries;
[CreateAssetMenu(fileName = "DeliverySettings", menuName = "ScheduleOne/Configurations/Settings/Delivery Settings", order = -1)]
public class DeliverySettings : ScheduleOne.Core.Settings.Framework.Settings
{
    [Tooltip("The fixed price for a delivery. Does not include the price of the items being delivered.")]
    public SerializableSettingsField<float> DeliveryFee;
    [Tooltip("How many in-game minutes does each individual item contribute to the total delivery time? For example, if this is set to 2.25 and the delivery has 20 items, then the total delivery time will be 45 in-game minutes.")]
    public SerializableSettingsField<float> DeliveryTimePerItem;
    [Tooltip("The minimum amount of in-game time (in minutes) that a delivery will take, regardless of how many items are in the delivery.")]
    public SerializableSettingsField<int> MinimumDeliveryTime;
    [Tooltip("The maximum amount of in-game time (in minutes) that a delivery will take, regardless of how many items are in the delivery.")]
    public SerializableSettingsField<int> MaximumDeliveryTime;
    [Tooltip("How many deliveries should be stored in the order history?")]
    public SerializableSettingsField<int> OrderHistoryLength;
    public override SettingsObject[] GetSettingsObjects();
}