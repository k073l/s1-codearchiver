namespace ScheduleOne.Gamepad;
public interface IHapticsManager
{
    const string PRESET_ACTION_PUNCH;
    const string PRESET_IMPACT_PUNCH;
    const string PRESET_ACTION_STAB;
    const string PRESET_IMPACT_STAB;
    const string PRESET_ACTION_BAT;
    const string PRESET_IMPACT_BAT;
    const string PRESET_ACTION_BULLET;
    const string PRESET_IMPACT_BULLET;
    const string PRESET_EXPLOSION;
    void Begin(string preset, float intensityMultiplier = 1f);
    void Begin(HapticsData data, float intensityMultiplier = 1f);
    void End();
    void Cancel();
    void SetMultiplier(float multiplier);
    float ForceToMultiplier(EHapticImpact impact, float force);
}