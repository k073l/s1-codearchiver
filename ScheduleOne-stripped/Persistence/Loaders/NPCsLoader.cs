using System;
using System.Collections.Generic;
using System.IO;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class NPCsLoader : Loader
{
    public virtual string NPCType => typeof(NPCCollectionData).Name;

    public override void Load(string mainPath);
}