using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Trash;
public class TrashBag : TrashItem
{
    public TrashContent Content { get; private set; } = new TrashContent();

    public void LoadContent(TrashContentData data);
    public override TrashItemData GetData();
}