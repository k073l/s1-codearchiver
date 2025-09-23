using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScheduleOne.Storage;
public static class StorageVisualizationUtility
{
    public static Dictionary<StorableItemInstance, int> GetVisualRepresentation(Dictionary<StorableItemInstance, int> inputDictionary, int TotalFootprintSize);
}