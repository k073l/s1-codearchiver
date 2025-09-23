using ScheduleOne.DevUtilities;
using ScheduleOne.Management.Presets;
using ScheduleOne.Management.Presets.Options;
using ScheduleOne.Management.SetterScreens;
using TMPro;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class PotPresetEditScreen : PresetEditScreen
{
    public GenericOptionUI SeedsUI;
    public GenericOptionUI AdditivesUI;
    private PotPreset castedPreset;
    protected override void Awake();
    protected virtual void Update();
    public override void Open(Preset preset);
    private void UpdateUI();
    public void SeedsUIClicked();
    public void AdditivesUIClicked();
}