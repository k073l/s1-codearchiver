using System;
using System.Collections.Generic;
using ScheduleOne.Configuration;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using UnityEngine;

namespace ScheduleOne.Equipping.Framework;
public static class EquippableHandlerService
{
    private class HandlerInfo
    {
        public Type DataType;
        public Type HandlerType;
        public HandlerInfo(Type dataType, Type handlerType);
    }

    private static EquipConfiguration _configuration;
    private static List<HandlerInfo> _defaultHandlers;
    static EquippableHandlerService();
    private static void SetupHandlerKeys();
    public static IEquippedItemHandler GetHandlerPrefab(EquippableData equippedData);
}