using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Effects.MixMaps;
[Serializable]
public class MixerMap : ScriptableObject
{
    public float MapRadius;
    public List<MixerMapEffect> Effects;
    public MixerMapEffect GetEffectAtPoint(Vector2 point);
    public MixerMapEffect GetEffect(Effect property);
}