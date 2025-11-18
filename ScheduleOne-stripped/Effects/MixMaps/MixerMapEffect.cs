using System;
using UnityEngine;

namespace ScheduleOne.Effects.MixMaps;
[Serializable]
public class MixerMapEffect
{
    public Vector2 Position;
    public float Radius;
    public Effect Property;
    public bool IsPointInEffect(Vector2 point);
}