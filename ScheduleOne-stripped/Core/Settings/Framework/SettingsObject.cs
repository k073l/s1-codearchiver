using System;

namespace ScheduleOne.Core.Settings.Framework;
[Serializable]
public abstract class SettingsObject
{
    public string Name { get; private set; }

    public SettingsObject(string name);
    public abstract void TryOverwriteWith(SettingsObject other);
    public abstract Type GetObjectType();
}