using HSVPicker;
using ScheduleOne.Core.Avatar.Properties;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Avatar.Creation;
public class AvatarObjectColorEntry : AvatarObjectPropertyEntry<ColorProperty>
{
    [SerializeField]
    private ColorPicker _colorPicker;
    public override void Initialize(ColorProperty property);
    protected override void PropertyValueChanged();
    private void OnColorPickedChanged(Color newColor);
}