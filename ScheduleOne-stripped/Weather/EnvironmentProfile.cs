using Funly.SkyStudio;
using UnityEngine;

namespace ScheduleOne.Weather;
[CreateAssetMenu(fileName = "EnvironmentProfile", menuName = "ScriptableObjects/Weather/Environment Profile")]
public class EnvironmentProfile : ScriptableObject
{
    [Header("Sky profile (TEMP - REPLACING)")]
    [SerializeField]
    private SkyProfile _skyProfile;
    [Header("Sky Settings")]
    [SerializeField]
    private SkySettings _skySettings;
    public SkySettings SkySettings => _skySettings;

    public SkyProfile GetSkyProfile();
}