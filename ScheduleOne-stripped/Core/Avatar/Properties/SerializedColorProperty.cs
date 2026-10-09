using System;
using UnityEngine;

namespace ScheduleOne.Core.Avatar.Properties;
[Serializable]
public struct SerializedColorProperty
{
    public string PropertyId;
    public Color Value;
    public SerializedColorProperty(string propertyId, Color value);
}