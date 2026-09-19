using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.Avatar.Creation;
public class AvatarEditorSliderLinker : AvatarEditorPropertyLinker<float>
{
    [Header("References")]
    [SerializeField]
    private Slider _sourceInput;
    [SerializeField]
    private Slider _targetInput;
    protected override void Awake();
    protected override bool HasSource();
    protected override float GetSourceValue();
    protected override float GetTargetValue();
    protected override bool AreValuesEqual(float value1, float value2);
    protected override void SetTargetValue(float value, bool notify);
}