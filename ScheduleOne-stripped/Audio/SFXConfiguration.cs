using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Configuration;
using ScheduleOne.Core;
using ScheduleOne.Core.Audio;
using ScheduleOne.Core.Settings;
using ScheduleOne.Core.Settings.Framework;
using UnityEngine;

namespace ScheduleOne.Audio;
[CreateAssetMenu(fileName = "SFXConfiguration", menuName = "ScheduleOne/Configurations/SFX Configuration")]
public class SFXConfiguration : Configuration<SFXSettings>
{
    public AudioSourceController ImpactSoundPrefab;
    public bool TryGetImpactTypeData(EImpactSound material, out ImpactSound data);
    public bool TryGetFootstepSoundGroup(EMaterialType materialType, out FootstepSound group);
}