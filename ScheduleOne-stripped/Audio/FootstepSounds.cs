using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Materials;
using UnityEngine;

namespace ScheduleOne.Audio;
public class FootstepSounds : MonoBehaviour
{
    [Serializable]
    public class FootstepSoundGroup
    {
        [Serializable]
        public class MaterialType
        {
            public EMaterialType type;
        }

        public string name;
        public List<AudioClip> clips;
        public List<MaterialType> appliesTo;
        public float PitchMin;
        public float PitchMax;
        public float Volume;
    }

    public const float COOLDOWN_TIME;
    [Range(0f, 4f)]
    public float BaseVolumeMultiplier;
    public List<AudioSourceController> sources;
    public List<FootstepSoundGroup> soundGroups;
    private Dictionary<EMaterialType, FootstepSoundGroup> materialFootstepSounds;
    private float lastStepTime;
    public float VolumeMultiplier { get; set; } = 1f;

    private void Awake();
    private void Start();
    public void Step(EMaterialType materialType, float hardness);
    public AudioSourceController GetFreeSource();
}