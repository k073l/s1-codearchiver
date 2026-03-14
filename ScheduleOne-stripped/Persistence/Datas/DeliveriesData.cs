using ScheduleOne.Delivery;

namespace ScheduleOne.Persistence.Datas;
public class DeliveriesData : SaveData
{
    public DeliveryInstance[] ActiveDeliveries;
    public VehicleData[] DeliveryVehicles;
    public DeliveryReceipt[] DeliveryHistory;
    public DeliveriesData(DeliveryInstance[] deliveries, VehicleData[] deliveryVehicles, DeliveryReceipt[] deliveryHistory);
}