using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace ScheduleOne.Effects;
public class VFXEffectHandler : EffectHandler
{
    [Header("Components")]
    [SerializeField]
    private List<VisualEffect> _visualEffects;
    public override void Activate();
    public override void Deactivate();
    public override void SetColorParameterForAll(string variable, Color value);
    public override void SetNumericParameter(string effectName, string variable, float value);
    public override void SetNumericParameterForAll(string variable, float value);
    public override void SetVectorParameter(string effectName, string variable, Vector3 value);
    public override void SetVectorParameter(string effectName, string variable, Vector2 value);
    public override void SetVectorParameterForAll(string variable, Vector3 value);
    public override void SetVectorParameterForAll(string variable, Vector2 value);
}