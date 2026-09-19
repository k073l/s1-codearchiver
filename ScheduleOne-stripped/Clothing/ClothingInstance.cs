using System;
using FishNet.Serializing;
using ScheduleOne.Core.Avatar;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Storage;
using UnityEngine;

namespace ScheduleOne.Clothing;
[Serializable]
public class ClothingInstance : StorableItemInstance
{
    public EClothingColor Color;
    public override string Name => base.Name + ((Color != EClothingColor.White) ? (" (" + Color.GetLabel() + ")") : string.Empty);

    public ClothingInstance(ItemDefinition definition, int quantity, EClothingColor color);
    public override ItemInstance GetCopy(int overrideQuantity = -1);
    public override ItemData GetItemData();
    public override void Write(Writer writer);
    public override void Read(Reader reader);
    public SerializedAvatarObject GetSerializedAvatarObject();
}