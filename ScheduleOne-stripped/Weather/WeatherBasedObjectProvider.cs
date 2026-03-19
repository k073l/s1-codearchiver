using System;
using UnityEngine;

namespace ScheduleOne.Weather;
[CreateAssetMenu(fileName = "WeatherBasedObjectProvider", menuName = "ScriptableObjects/Weather/Weather Based Object Provider")]
public class WeatherBasedObjectProvider : ScriptableObject
{
    [Serializable]
    public enum EvaluationType
    {
        LessThan,
        Equals,
        GreaterThan,
        Blend
    }

    [Flags]
    public enum ConditionFlags
    {
        None = 0,
        Sunny = 1,
        Cloudy = 2,
        Rainy = 4,
        Stormy = 8,
        Snowy = 0x10,
        Foggy = 0x20,
        Windy = 0x40,
        Hail = 0x80,
        Sleet = 0x100
    }

    [SerializeField]
    private ConditionFlags _selectedConditions;
    [SerializeField]
    private WeatherConditions _conditions;
    [SerializeField]
    private EvaluationType _evaluationType;
    [SerializeField]
    private Object _object;
    public Object Object => _object;

    public bool DoesSatisfyConditions(WeatherConditions activeConditions);
    public float GetAverageBlend(WeatherConditions activeConditions);
    private float GetConditionBlendValue(float activeValue, float condition);
    private bool EvaluateConditions(float conditionValue, float conditionThreshold);
}