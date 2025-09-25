using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class ShopManagerData : SaveData
{
    public ShopData[] Shops;
    public ShopManagerData(ShopData[] shops);
}