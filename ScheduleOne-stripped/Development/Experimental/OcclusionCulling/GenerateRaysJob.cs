using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace ScheduleOne.Development.Experimental.OcclusionCulling;
[BurstCompile]
public struct GenerateRaysJob : IJobParallelFor
{
    [ReadOnly]
    public float3 Origin;
    [ReadOnly]
    public float CellSize;
    [ReadOnly]
    public int CellsX;
    [ReadOnly]
    public int CellsY;
    [ReadOnly]
    public float MaxDistance;
    [ReadOnly]
    public int ObjectCount;
    [ReadOnly]
    public int RaysPerObject;
    [ReadOnly]
    [NativeDisableParallelForRestriction]
    [ReadOnly]
    public NativeArray<float3> ObjectCenters;
    [ReadOnly]
    public int LayerMask;
    [WriteOnly]
    [NativeDisableParallelForRestriction]
    public NativeArray<RaycastCommand> Commands;
    public void Execute(int cellIndex);
}