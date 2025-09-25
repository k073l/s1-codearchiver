using System;
using System.IO;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.GameTime;
using ScheduleOne.NPCs;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Quests;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class QuestsLoader : Loader
{
    public override void Load(string mainPath);
}