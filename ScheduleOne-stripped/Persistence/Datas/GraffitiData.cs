using System.Collections.Generic;

namespace ScheduleOne.Persistence.Datas;
public class GraffitiData : SaveData
{
    public List<SpraySurfaceData> SpraySurfaces;
    public GraffitiData(List<SpraySurfaceData> spraySurfaces);
}