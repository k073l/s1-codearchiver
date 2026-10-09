using System;

namespace ScheduleOne.SpecialCustomers;
[Serializable]
public enum SpecialCustomerPhase
{
    Inactive,
    WaitingForArrival,
    Arrived
}