using ScheduleOne.Delivery;

namespace ScheduleOne.Persistence.Datas;
public class DeliveriesData : SaveData
{
    public DeliveryInstance[] ActiveDeliveries;
    public VehicleData[] DeliveryVehicles;
    public DeliveriesData(DeliveryInstance[] deliveries, VehicleData[] deliveryVehicles);
}