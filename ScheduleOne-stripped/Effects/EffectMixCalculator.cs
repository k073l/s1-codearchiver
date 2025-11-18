using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Effects.MixMaps;
using ScheduleOne.Product;
using ScheduleOne.StationFramework;
using UnityEngine;

namespace ScheduleOne.Effects;
public static class EffectMixCalculator
{
    private class Reaction
    {
        public Effect Existing;
        public Effect Output;
    }

    public const int MAX_PROPERTIES;
    public const float MAX_DELTA_DIFFERENCE;
    public static List<Effect> MixProperties(List<Effect> existingProperties, Effect newProperty, EDrugType drugType);
    public static void Shuffle<T>(List<T> list, int seed);
}