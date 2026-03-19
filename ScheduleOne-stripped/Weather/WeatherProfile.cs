using UnityEngine;

namespace ScheduleOne.Weather;
[CreateAssetMenu(fileName = "WeatherProfile", menuName = "ScriptableObjects/Weather/Weather Profile")]
public class WeatherProfile : ScriptableObject
{
    [SerializeField]
    private string _id;
    [SerializeField]
    private SkySettings _skySettings;
    [SerializeField]
    private WeatherVolume _weatherVolumePrefab;
    [SerializeField]
    private WeatherConditions _conditions;
    public string Id => _id;
    public WeatherVolume WeatherVolumePrefab => _weatherVolumePrefab;
    public SkySettings SkySettings => _skySettings;
    public WeatherConditions Conditions => _conditions;
}