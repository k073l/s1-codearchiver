using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;

namespace ScheduleOne.UI.Settings;
public class AudioSlider : SettingsSlider
{
    public const float MULTIPLIER;
    public bool Master;
    public EAudioType AudioType;
    protected virtual void Start();
    protected override void OnValueChanged(float value);
}