using System;
using FishNet.Serializing;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Storage;

namespace ScheduleOne.ItemFramework;
[Serializable]
public class QualityItemInstance : StorableItemInstance
{
    public EQuality Quality;
    public QualityItemInstance(ItemDefinition definition, int quantity, EQuality quality);
    public override bool CanStackWith(ItemInstance other, bool checkQuantities = true);
    public override ItemInstance GetCopy(int overrideQuantity = -1);
    public override ItemData GetItemData();
    public void SetQuality(EQuality quality);
    public override void Write(Writer writer);
    public override void Read(Reader reader);
}