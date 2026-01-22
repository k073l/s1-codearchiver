using System.Collections.Generic;

namespace ScheduleOne.Persistence.Datas;
public class GraffitiData : SaveData
{
    public List<WorldSpraySurfaceData> SpraySurfaces;
    public GraffitiData(List<WorldSpraySurfaceData> spraySurfaces);
}