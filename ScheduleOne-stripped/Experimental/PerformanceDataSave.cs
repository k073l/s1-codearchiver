using System;
using UnityEngine;

namespace ScheduleOne.Experimental;
[Serializable]
public class PerformanceDataSave
{
    public int ChunkAmountX;
    public int ChunkAmountY;
    public int ChunkSize;
    public Vector3 StartPosition;
    public float MinFps;
    public float MaxFps;
    public float[] AverageFpsData;
}