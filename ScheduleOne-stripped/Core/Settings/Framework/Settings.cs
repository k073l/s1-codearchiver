using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Core.Settings.Framework;
[Serializable]
public abstract class Settings : ScriptableObject
{
    private class SerializedObjectList
    {
        public List<SerializedObject> Fields;
        public SerializedObjectList(List<SerializedObject> fields);
    }

    [Serializable]
    private class SerializedObject
    {
        public string Name;
        public string Value;
        public SerializedObject(string name, string value);
    }

    public virtual int Version => 1;

    public abstract SettingsObject[] GetSettingsObjects();
    public string Serialize();
    public void Deserialize(string json);
}