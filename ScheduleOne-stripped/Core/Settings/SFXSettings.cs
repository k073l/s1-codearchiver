using System;
using System.Collections.Generic;
using ScheduleOne.Core.Audio;
using ScheduleOne.Core.Settings.Framework;
using UnityEngine;

namespace ScheduleOne.Core.Settings;
[CreateAssetMenu(fileName = "SFXSettings", menuName = "ScheduleOne/Configurations/Settings/SFX Settings", order = -1)]
public class SFXSettings : ScheduleOne.Core.Settings.Framework.Settings
{
    [Serializable]
    public class ImpactSound
    {
        [Tooltip("What sort of impact sound does this hold data for?")]
        public EImpactSound ImpactSoundType;
        [Tooltip("List of audio clips to randomly choose from when playing an impact sound of this type.")]
        public AudioClip[] Clips;
        [Tooltip("Volume of the impact sound at minimum momentum")]
        public float VolumeAtMinimumMomentum;
        [Tooltip("Volume of the impact sound at maximum momentum.")]
        public float VolumeAtMaximumMomentum;
        [Tooltip("Pitch of the impact sound at minimum momentum.")]
        public float PitchAtMinimumMomentum;
        [Tooltip("Pitch of the impact sound at maximum momentum.")]
        public float PitchAtMaximumMomentum;
        public AudioClip GetRandomClip();
    }

    [Serializable]
    public class FootstepSound
    {
        [Tooltip("List of audio clips to randomly choose from when playing a footstep sound of this type.")]
        public AudioClip[] Clips;
        [Tooltip("What materials do these footstep sounds play for?")]
        public List<EMaterialType> AppliesTo;
        [Tooltip("Default volume for footsteps of this type.")]
        public float Volume;
        [Tooltip("Minimum random pitch")]
        public float MinPitch;
        [Tooltip("Maximum random pitch")]
        public float MaxPitch;
        public AudioClip GetRandomClip();
    }

    [Tooltip("Maximum range (in meters) at which impact sounds will play. Beyond this distance, impact sounds will not be played to optimize performance.")]
    public SerializableSettingsField<float> ImpactSoundMaxRange;
    [Tooltip("Number of audio sources to pre-instantiate and keep in a pool for playing SFX.")]
    public SerializableSettingsField<int> AudioSourcePoolSize;
    [Tooltip("Contains data for playing a sound for physical impacts.")]
    public ReplaceableSettingsList<ImpactSound> ImpactSounds;
    [Tooltip("Contains data for playing footstep sounds.")]
    public ReplaceableSettingsList<FootstepSound> FootstepSounds;
    public override SettingsObject[] GetSettingsObjects();
}