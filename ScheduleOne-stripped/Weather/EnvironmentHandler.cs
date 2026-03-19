using System;

namespace ScheduleOne.Weather;
public static class EnvironmentHandler
{
    private static WeatherChangeHandler _onWeatherChange;
    private static WeatherEntityHandler _onRegisterWeatherEntity;
    private static WeatherEntityHandler _onUnregisterWeatherEntity;
    public static void RaiseWeatherChange(WeatherConditions newConditions);
    public static void RegisterWeatherEntity(IWeatherEntity entity);
    public static void UnregisterWeatherEntity(IWeatherEntity entity);
    public static void SubscribeToWeatherChange(WeatherChangeHandler handler);
    public static void UnsubscribeFromWeatherChange(WeatherChangeHandler handler);
    public static void SubscribeToOnRegisterWeatherEntity(WeatherEntityHandler handler);
    public static void UnsubscribeFromOnRegisterWeatherEntity(WeatherEntityHandler handler);
    public static void SubscribeToOnUnregisterWeatherEntity(WeatherEntityHandler handler);
    public static void UnsubscribeFromOnUnregisterWeatherEntity(WeatherEntityHandler handler);
}