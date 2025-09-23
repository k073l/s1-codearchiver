using ScheduleOne.ItemFramework;

namespace ScheduleOne.Economy;
public static class StandardsMethod
{
    public static string GetName(this ECustomerStandard property);
    public static EQuality GetCorrespondingQuality(this ECustomerStandard property);
}