using System;
using UnityEngine;

namespace ScheduleOne.Experimental;
[Serializable]
public class WheelFrictionSettings
{
    public float ExtremumSlip;
    public float ExtremumValue;
    public float AsymptoteSlip;
    public float AsymptoteValue;
    public float Stiffness;
    public WheelFrictionSettings Blend(WheelFrictionSettings other, float t);
}