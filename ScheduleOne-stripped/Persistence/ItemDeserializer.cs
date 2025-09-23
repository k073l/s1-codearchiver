using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.ItemLoaders;
using UnityEngine;

namespace ScheduleOne.Persistence;
public static class ItemDeserializer
{
    public static ItemInstance LoadItem(string itemString);
}