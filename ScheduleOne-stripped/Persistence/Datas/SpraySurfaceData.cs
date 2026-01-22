using System;
using System.Collections.Generic;
using ScheduleOne.Graffiti;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class SpraySurfaceData : SaveData
{
    public List<SprayStroke> Strokes;
    public bool ContainsCartelGraffiti;
    public SpraySurfaceData(List<SprayStroke> strokes, bool containsCartelGraffiti);
}