using HSVPicker;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Avatar.Creation;
public class AvatarEditorColorLinker : AvatarEditorPropertyLinker<Color>
{
    [Header("References")]
    [SerializeField]
    private ColorPicker _sourceInput;
    [SerializeField]
    private ColorPicker _targetInput;
    protected override void Awake();
    protected override bool HasSource();
    protected override Color GetSourceValue();
    protected override Color GetTargetValue();
    protected override bool AreValuesEqual(Color value1, Color value2);
    protected override void SetTargetValue(Color value, bool notify);
}