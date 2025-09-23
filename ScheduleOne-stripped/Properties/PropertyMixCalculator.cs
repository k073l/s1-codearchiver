using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Product;
using ScheduleOne.Properties.MixMaps;
using ScheduleOne.StationFramework;
using UnityEngine;

namespace ScheduleOne.Properties;
public static class PropertyMixCalculator
{
    private class Reaction
    {
        public Property Existing;
        public Property Output;
    }

    public const int MAX_PROPERTIES;
    public const float MAX_DELTA_DIFFERENCE;
    public static List<Property> MixProperties(List<Property> existingProperties, Property newProperty, EDrugType drugType);
    public static void Shuffle<T>(List<T> list, int seed);
}