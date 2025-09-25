using ScheduleOne.Management.Presets.Options;
using UnityEngine;

namespace ScheduleOne.Management.Presets;
public class PotPreset : Preset
{
    public ItemList Seeds;
    public ItemList Additives;
    protected static PotPreset DefaultPreset { get; set; }

    public override Preset GetCopy();
    public override void CopyTo(Preset other);
    public override void InitializeOptions();
    public static PotPreset GetDefaultPreset();
    public static PotPreset GetNewBlankPreset();
}