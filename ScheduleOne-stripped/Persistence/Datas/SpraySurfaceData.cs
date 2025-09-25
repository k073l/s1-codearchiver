using System;
using System.Collections.Generic;
using ScheduleOne.Graffiti;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class SpraySurfaceData : SaveData
{
    public string GUID;
    public bool HasDrawingBeenFinalized;
    public List<SprayStroke> Strokes;
    public SpraySurfaceData(string guid, bool hasDrawingBeenFinalized, List<SprayStroke> strokes);
}