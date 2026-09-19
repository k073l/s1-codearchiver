using System.Collections.Generic;
using ScheduleOne.NPCs;
using ScheduleOne.Product;

namespace ScheduleOne.SpecialCustomers;
public interface IActivityHandler
{
    ProductItemInstance GetProduct();
    void ReassignNPCs(List<SpecialCustomer> npcs, string previousActivity);
    bool HasProduct();
    int GetProductQauntity();
    List<SpecialCustomer> GetCustomers();
}