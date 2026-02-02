using System;
using System.Collections.Generic;
using ScheduleOne.Graffiti;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class WorldSpraySurfaceData : SpraySurfaceData
{
    public string GUID;
    public bool HasDrawingBeenFinalized;
    public WorldSpraySurfaceData(List<SprayStroke> strokes, bool containsCartelGraffiti, string guid, bool hasBeenFinalized);
}