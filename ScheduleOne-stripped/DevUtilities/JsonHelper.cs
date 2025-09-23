using System;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public static class JsonHelper
{
    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }

    public static T[] FromJson<T>(string json);
    public static string ToJson<T>(T[] array);
    public static string ToJson<T>(T[] array, bool prettyPrint);
}