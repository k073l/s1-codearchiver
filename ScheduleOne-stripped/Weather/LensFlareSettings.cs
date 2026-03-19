using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScheduleOne.Weather;
[CreateAssetMenu(fileName = "LensFlareSettings", menuName = "ScriptableObjects/Weather/Lens Flare Settings")]
public class LensFlareSettings : ScriptableObject
{
    [Serializable]
    public class LensFlareSettingsGroup
    {
        public LensFlareDataSRP LensFlare;
        public float Intensity;
    }

    [SerializeField]
    private LensFlareSettingsGroup[] lensFlareGroups;
    public bool TryGetLensFlareSettings(LensFlareDataSRP lensFlare, out LensFlareSettingsGroup group);
    public LensFlareSettingsGroup[] GetLensFlareGroups();
}