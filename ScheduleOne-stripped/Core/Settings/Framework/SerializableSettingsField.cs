using System;
using UnityEngine;

namespace ScheduleOne.Core.Settings.Framework;
[Serializable]
public class SerializableSettingsField<T> : SettingsField<T>, ISerializable
{
    [Serializable]
    private class SerializedField
    {
        public T Value;
        public SerializedField(T value);
    }

    public SerializableSettingsField(string name, T defaultValue);
    public string Serialize();
    public void Deserialize(string value);
}