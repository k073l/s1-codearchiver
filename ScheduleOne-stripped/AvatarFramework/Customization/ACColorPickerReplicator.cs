using HSVPicker;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Customization;
public class ACColorPickerReplicator : ACReplicator
{
    public ColorPicker picker;
    protected override void AvatarSettingsChanged(AvatarSettings newSettings);
}