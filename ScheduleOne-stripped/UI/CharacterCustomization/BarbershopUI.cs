using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.CharacterCustomization;
public class BarbershopUI : CharacterCustomizationUI
{
    public HSVColorPicker ColorPicker;
    public Button ApplyColorButton;
    public CharacterCustomizationCategory ColorCategory;
    public CharacterCustomizationCategory HairStyleCategory;
    public CharacterCustomizationCategory BeardCategory;
    private Color appliedColor;
    protected override void Awake();
    public override bool IsOptionCurrentlyApplied(CharacterCustomizationOption option);
    public override void OptionSelected(CharacterCustomizationOption option);
    public override void OptionDeselected(CharacterCustomizationOption option);
    public override void Open();
    private void ColorFieldChanged(Color color);
    private void ApplyColorChange();
    private void RevertColorChange();
}