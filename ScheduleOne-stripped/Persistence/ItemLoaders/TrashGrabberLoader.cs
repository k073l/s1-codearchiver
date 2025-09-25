using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts.WateringCan;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.ItemLoaders;
public class TrashGrabberLoader : ItemLoader
{
    public override string ItemType => typeof(TrashGrabberData).Name;

    public override ItemInstance LoadItem(string itemString);
}