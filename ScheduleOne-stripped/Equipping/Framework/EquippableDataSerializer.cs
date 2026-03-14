using System;
using FishNet.Serializing;
using ScheduleOne.Core;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Equipping.Framework;
public static class EquippableDataSerializer
{
    public static void WriteEquippableData(this Writer writer, EquippableData value);
    public static EquippableData ReadEquippableData(this Reader reader);
}