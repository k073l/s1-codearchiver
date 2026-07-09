using UnityEngine;

namespace ScheduleOne.Core.Weather;
[CreateAssetMenu(fileName = "WeatherProfile", menuName = "ScriptableObjects/Weather/Weather Profile")]
public class WeatherProfile : ScriptableObject
{
    [SerializeField]
    private string _id;
    [SerializeField]
    private SkySettings _skySettings;
    [SerializeField]
    private WeatherConditions _conditions;
    [SerializeField]
    private CloudSettings _cloudSettings;
    [SerializeField]
    private RainSettings _rainSettings;
    [SerializeField]
    private ThunderSettings _thunderSettings;
    public string Id => _id;
    public SkySettings SkySettings => _skySettings;
    public CloudSettings CloudSettings => _cloudSettings;
    public RainSettings RainSettings => _rainSettings;
    public ThunderSettings ThunderSettings => _thunderSettings;
    public WeatherConditions Conditions => _conditions;
}