using System;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Configuration;
public class ConfigurationService : PersistentSingleton<ConfigurationService>
{
    [SerializeField]
    private BaseConfiguration[] _configurations;
    public BaseConfiguration[] Configurations => _configurations;

    protected override void Awake();
    private void ResetConfigurations();
    public bool TryGetConfiguration<T>(out T configuration)
        where T : BaseConfiguration;
    public bool TryGetConfiguration(string configurationName, out BaseConfiguration configuration);
    public void GetConfigurationAndListenForChanges<T>(Action<BaseConfiguration> onConfigChanged)
        where T : BaseConfiguration;
    public void UnsubscribeFromConfigurationChanges<T>(Action<BaseConfiguration> onConfigChanged)
        where T : BaseConfiguration;
}