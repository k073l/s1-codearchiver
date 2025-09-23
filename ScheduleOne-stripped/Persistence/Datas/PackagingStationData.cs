using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class PackagingStationData : GridItemData
{
    public ItemSet Contents;
    public PackagingStationData(Guid guid, ItemInstance item, int loadOrder, Grid grid, Vector2 originCoordinate, int rotation, ItemSet contents);
}