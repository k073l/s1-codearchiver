using System;
using UnityEngine;

namespace ScheduleOne.Core.Avatar.Properties;
[Serializable]
public class ColorProperty : AvatarProperty<Color>
{
    public ColorProperty(string name, Color value, bool editable = true);
    public SerializedColorProperty Serialize();
    protected override EType GetPropertyType();
}