using UnityEngine;

namespace ScheduleOne.Temperature;
public static class TemperatureAlgorithm
{
    public const float NegligibleInfluenceThreshold;
    public static float GetTemperatureAtPoint(float ambientTemperature, Vector3 originPoint, Vector3 point, TemperatureEmitterInfo[] emitters);
}