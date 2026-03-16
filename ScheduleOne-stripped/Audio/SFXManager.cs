using System.Collections.Generic;
using ScheduleOne.Configuration;
using ScheduleOne.Core;
using ScheduleOne.Core.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Audio;
public class SFXManager : Singleton<SFXManager>
{
    private static float ImpactSoundMaxRangeSquared;
    private List<AudioSourceController> _soundPool;
    private List<AudioSourceController> _soundsInUse;
    private SFXConfiguration _configuration;
    protected override void Awake();
    protected override void OnDestroy();
    private void Update();
    public void PlayImpactSound(EImpactSound material, Vector3 position, float momentum);
    public void PlayFootstepSound(EMaterialType materialType, float volume, Vector3 position);
    public void SetConfiguration(BaseConfiguration baseConfiguration);
    private void SetupSoundPool();
    private bool TryPullAudioSource(out AudioSourceController source);
}