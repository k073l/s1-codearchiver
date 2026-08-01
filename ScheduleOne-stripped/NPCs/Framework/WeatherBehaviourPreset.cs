using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[CreateAssetMenu(menuName = "ScheduleOne/NPCs/Presets/WeatherBehaviour Preset")]
public class WeatherBehaviourPreset : ValueProviderScriptableObject<WeatherBehaviour>
{
    public WeatherBehaviour value;
    public override WeatherBehaviour GetValue();
}