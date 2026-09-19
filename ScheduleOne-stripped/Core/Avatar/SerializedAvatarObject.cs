using System;
using ScheduleOne.Core.Avatar.Properties;

namespace ScheduleOne.Core.Avatar;
[Serializable]
public struct SerializedAvatarObject
{
    [Serializable]
    public struct PropertySet
    {
        public string[] Properties;
        public PropertySet(string[] properties);
        public PropertySet Clone();
    }

    public string Id;
    public SerializedColorProperty[] Colors;
    public static SerializedAvatarObject Null => new SerializedAvatarObject(string.Empty, new SerializedColorProperty[0]);

    public SerializedAvatarObject(string objectId, SerializedColorProperty[] colors);
    public bool IsNull();
    public SerializedAvatarObject Clone();
}