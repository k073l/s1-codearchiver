using System;
using UnityEngine;

namespace ScheduleOne.Core;
[Serializable]
public class DynamicGradient
{
    public Gradient Gradient;
    [Range(0f, 2f)]
    [SerializeField]
    private float _saturationMultiplier;
    [Range(0f, 2f)]
    [SerializeField]
    private float _brightnessMultiplier;
    public Color Evaluate(float value);
}