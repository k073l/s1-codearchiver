using System;
using ScheduleOne.DevUtilities;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class ShopData : SaveData
{
    public string ShopCode;
    public StringIntPair[] ItemStockQuantities;
    public ShopData(string shopCode, StringIntPair[] itemStockQuantities);
}