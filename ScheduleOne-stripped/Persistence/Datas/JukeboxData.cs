using System;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
public class JukeboxData : GridItemData
{
    public Jukebox.JukeboxState State;
    public JukeboxData(Guid guid, ItemInstance item, int loadOrder, Grid grid, Vector2 originCoordinate, int rotation, Jukebox.JukeboxState state);
}