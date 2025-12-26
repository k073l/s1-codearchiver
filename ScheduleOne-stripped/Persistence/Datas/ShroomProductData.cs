using System;
using ScheduleOne.Product;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class ShroomProductData : ProductData
{
    public ShroomAppearanceSettings AppearanceSettings;
    public ShroomProductData(string name, string id, EDrugType drugType, string[] properties, ShroomAppearanceSettings appearanceSettings);
}