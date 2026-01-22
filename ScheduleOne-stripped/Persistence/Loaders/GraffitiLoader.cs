using System;
using ScheduleOne.Graffiti;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class GraffitiLoader : Loader
{
    public override void Load(string mainPath);
    private void LoadSpraySurface(WorldSpraySurfaceData surfaceData);
    private void EnsureStrokesHaveValidSize(SpraySurfaceData surfaceData);
}