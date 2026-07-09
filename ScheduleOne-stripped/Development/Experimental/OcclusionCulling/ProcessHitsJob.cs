using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace ScheduleOne.Development.Experimental.OcclusionCulling;
[BurstCompile]
public struct ProcessHitsJob : IJobParallelFor
{
    [ReadOnly]
    public int ObjectCount;
    [ReadOnly]
    public int RaysPerObject;
    [ReadOnly]
    public NativeArray<RaycastHit> Hits;
    [WriteOnly]
    [NativeDisableParallelForRestriction]
    public NativeArray<byte> VisibilityData;
    public void Execute(int cellIndex);
}