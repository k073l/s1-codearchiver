using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.Temperature;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class AirConditionerData : GridItemData
{
    public AirConditioner.EMode Mode;
    public AirConditionerData(Guid guid, ItemInstance item, int loadOrder, Grid grid, Vector2 originCoordinate, int rotation, AirConditioner.EMode mode);
}