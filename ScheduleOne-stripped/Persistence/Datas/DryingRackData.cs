using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
public class DryingRackData : GridItemData
{
    public ItemSet Input;
    public ItemSet Output;
    public DryingOperation[] DryingOperations;
    public DryingRackData(Guid guid, ItemInstance item, int loadOrder, Grid grid, Vector2 originCoordinate, int rotation, ItemSet input, ItemSet output, DryingOperation[] dryingOperations);
}