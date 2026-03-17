using UnityEngine;

namespace ScheduleOne.Weather;
public interface IWeatherEntity
{
    string WeatherVolume { get; set; }

    Transform Transform { get; }

    bool IsUnderCover { get; set; }

    void OnWeatherChange(WeatherConditions newConditions);
    void OnUpdateWeatherEntity();
}