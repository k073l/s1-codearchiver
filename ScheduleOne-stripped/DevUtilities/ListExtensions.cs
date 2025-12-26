using System;
using System.Collections.Generic;

namespace ScheduleOne.DevUtilities;
public static class ListExtensions
{
    public static void Shuffle<T>(this IList<T> list, int seed = -1);
}