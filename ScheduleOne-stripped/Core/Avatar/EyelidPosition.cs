using System;
using UnityEngine;

namespace ScheduleOne.Core.Avatar;
[Serializable]
public struct EyelidPosition
{
    [Range(0f, 1f)]
    public float TopLidOpenness;
    [Range(0f, 1f)]
    public float BottomLidOpenness;
    public static EyelidPosition Alert => new EyelidPosition(0.8f, 0.7f);
    public static EyelidPosition Default => new EyelidPosition(0.5f, 0.4f);
    public static EyelidPosition Relaxed => new EyelidPosition(0.3f, 0.3f);
    public static EyelidPosition Sedated => new EyelidPosition(0.18f, 0.18f);
    public static EyelidPosition Closed => new EyelidPosition(0f, 0f);

    public EyelidPosition(float topLidOpenness, float bottomLidOpenness);
    public override string ToString();
    public static EyelidPosition Lerp(EyelidPosition start, EyelidPosition end, float lerp);
}