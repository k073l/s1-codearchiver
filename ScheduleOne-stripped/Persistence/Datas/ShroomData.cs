using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class ShroomData : ProductItemData
{
    public ShroomData(string iD, int quantity, string quality, string packagingID);
}