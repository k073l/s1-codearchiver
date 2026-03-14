using System;
using System.Collections.Generic;
using FishNet.Serializing;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Storage;
using ScheduleOne.Trash;

namespace ScheduleOne.ObjectScripts.WateringCan;
[Serializable]
public class TrashGrabberInstance : StorableItemInstance
{
    public const int TRASH_CAPACITY;
    private TrashContent Content;
    public TrashGrabberInstance(ItemDefinition definition, int quantity);
    public override ItemInstance GetCopy(int overrideQuantity = -1);
    public void LoadContentData(TrashContentData content);
    public override ItemData GetItemData();
    public void AddTrash(string id, int quantity);
    public void RemoveTrash(string id, int quantity);
    public void ClearTrash();
    public int GetTotalSize();
    public List<string> GetTrashIDs();
    public List<int> GetTrashQuantities();
    public List<ushort> GetTrashUshortQuantities();
    public override void Write(Writer writer);
    public override void Read(Reader reader);
}