using UnityEngine;

namespace ScheduleOne.Weather;
public class SkyOverrideEnclosure : WorldEnclosure
{
    [Header("Settings")]
    [Tooltip("Higher priority overrides will take precedence over lower ones")]
    [SerializeField]
    private int _priority;
    [SerializeField]
    private SkySettings _skySettings;
    public int Priority => _priority;
    public SkySettings SkySettings => _skySettings;
}