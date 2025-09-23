using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
public class MixingStationData : GridItemData
{
    public ItemSet ProductContents;
    public ItemSet MixerContents;
    public ItemSet OutputContents;
    public MixOperation CurrentMixOperation;
    public int CurrentMixTime;
    public MixingStationData(Guid guid, ItemInstance item, int loadOrder, Grid grid, Vector2 originCoordinate, int rotation, ItemSet productContents, ItemSet mixerContents, ItemSet outputContents, MixOperation currentMixOperation, int currentMixTime);
}