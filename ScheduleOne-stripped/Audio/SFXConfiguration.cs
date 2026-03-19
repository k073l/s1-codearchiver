using System.Linq;
using ScheduleOne.Configuration;
using ScheduleOne.Core;
using ScheduleOne.Core.Audio;
using ScheduleOne.Core.Settings;
using UnityEngine;

namespace ScheduleOne.Audio;
[CreateAssetMenu(fileName = "SFXConfiguration", menuName = "ScheduleOne/Configurations/SFX Configuration")]
public class SFXConfiguration : Configuration<SFXSettings>
{
    public AudioSourceController ImpactSoundPrefab;
    public bool TryGetImpactTypeData(EImpactSound material, out SFXSettings.ImpactSound data);
    public bool TryGetFootstepSoundGroup(EMaterialType materialType, out SFXSettings.FootstepSound group);
}