using UnityEngine;

namespace ScheduleOne.Core.Weather;
public interface IEnvironmentManager
{
    SkyState SkyState { get; }

    void SetWeather(string type);
    void TriggerLightningEvent();
    void TriggerTargetedLightningEvent(Vector3 target);
    void TriggerDistantThunder();
}