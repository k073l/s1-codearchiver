using ScheduleOne.Map;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.SpecialCustomers;
public class SpecialCustomerGroupPOI : POI
{
    private Color groupColor;
    public override void InitializeUI();
    public void SetGroupColor(Color color);
}