using System;
using ScheduleOne.Core.Settings.Framework;
using UnityEngine;

namespace ScheduleOne.Configuration;
public abstract class BaseConfiguration : ScriptableObject
{
    public Action<BaseConfiguration> OnConfigurationChanged;
    public abstract void ResetConfigurationToDefault();
    public virtual void ValidateConfiguration();
    public abstract Settings GetSettings();
}