using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Effects;
[Serializable]
public class EffectSettingsWrapper
{
    public List<NumericParameter> NumericParameters;
    public List<GradientParameter> GradientParameters;
    public float GetNumericParameter(string variable);
    public void SetNumericParameter(string variable, float value);
    public Gradient GetGradientParameter(string variable);
    public void SetGradientParameter(string variable, Gradient value);
}