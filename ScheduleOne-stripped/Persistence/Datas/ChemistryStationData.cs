using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
public class ChemistryStationData : GridItemData
{
    public ItemSet InputContents;
    public ItemSet OutputContents;
    public string CurrentRecipeID;
    public EQuality ProductQuality;
    public Color StartLiquidColor;
    public float LiquidLevel;
    public int CurrentTime;
    public ChemistryStationData(Guid guid, ItemInstance item, int loadOrder, Grid grid, Vector2 originCoordinate, int rotation, ItemSet inputContents, ItemSet outputContents, string currentRecipeID, EQuality productQuality, Color startLiquidColor, float liquidLevel, int currentTime);
}