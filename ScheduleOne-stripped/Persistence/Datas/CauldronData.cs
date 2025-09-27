using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
public class CauldronData : GridItemData
{
    public ItemSet Ingredients;
    public ItemSet Liquid;
    public ItemSet Output;
    public int RemainingCookTime;
    public EQuality InputQuality;
    public CauldronData(Guid guid, ItemInstance item, int loadOrder, Grid grid, Vector2 originCoordinate, int rotation, ItemSet ingredients, ItemSet liquid, ItemSet output, int remainingCookTime, EQuality inputQuality);
}