using ScheduleOne.Configuration;
using ScheduleOne.Core.Deliveries;
using UnityEngine;

namespace ScheduleOne.Delivery;
[CreateAssetMenu(fileName = "DeliveryConfiguration", menuName = "ScheduleOne/Configurations/Delivery Configuration")]
public class DeliveryConfiguration : Configuration<DeliverySettings>
{
}