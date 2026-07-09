using System;
using UnityEngine;

namespace ScheduleOne.Core.Weather;
public static class EnvironmentHandler
{
    private static IEnvironmentManager _manager;
    private static WeatherChangeHandler _onWeatherChange;
    private static WeatherEntityHandler _onRegisterWeatherEntity;
    private static WeatherEntityHandler _onUnregisterWeatherEntity;
    private static EnclosureHandler _onRegisterEnclosure;
    private static EnclosureHandler _onUnregisterEnclosure;
    public static void RegisterManager(IEnvironmentManager manager);
    public static void UnregisterManager(IEnvironmentManager manager);
    private static bool HasRegisteredManager();
    public static SkyState GetSkyState();
    public static void SetWeather(string type);
    public static void TriggerLightningEvent();
    public static void TriggerTargetedLightningEvent(Vector3 target);
    public static void TriggerDistantThunder();
    public static void RaiseWeatherChange(WeatherConditions newConditions);
    public static void RegisterWeatherEntity(IWeatherEntity entity);
    public static void UnregisterWeatherEntity(IWeatherEntity entity);
    public static void RegisterEnclosure(WorldEnclosure enclosure);
    public static void UnregisterEnclosure(WorldEnclosure enclosure);
    public static void SubscribeToWeatherChange(WeatherChangeHandler handler);
    public static void UnsubscribeFromWeatherChange(WeatherChangeHandler handler);
    public static void SubscribeToOnRegisterWeatherEntity(WeatherEntityHandler handler);
    public static void UnsubscribeFromOnRegisterWeatherEntity(WeatherEntityHandler handler);
    public static void SubscribeToOnUnregisterWeatherEntity(WeatherEntityHandler handler);
    public static void UnsubscribeFromOnUnregisterWeatherEntity(WeatherEntityHandler handler);
    public static void SubscribeToRegisterEnclosure(EnclosureHandler handler);
    public static void UnsubscribeFromRegisterEnclosure(EnclosureHandler handler);
    public static void SubscribeToUnregisterEnclosure(EnclosureHandler handler);
    public static void UnsubscribeFromUnregisterEnclosure(EnclosureHandler handler);
}