using System;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class ProductItemData : QualityItemData
{
    public string PackagingID;
    public ProductItemData(string iD, int quantity, string quality, string packagingID);
}