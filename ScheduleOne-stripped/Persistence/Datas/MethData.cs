using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class MethData : ProductItemData
{
    public MethData(string iD, int quantity, string quality, string packagingID);
}