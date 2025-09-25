using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Storage;
using UnityEngine;

namespace ScheduleOne.Persistence.ItemLoaders;
public class ItemLoader
{
    public virtual string ItemType => typeof(ItemData).Name;

    public ItemLoader();
    public virtual ItemInstance LoadItem(string itemString);
    protected T LoadData<T>(string itemString)
        where T : ItemData;
}