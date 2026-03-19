using System;
using UnityEngine;

namespace ScheduleOne.Experimental;
[CreateAssetMenu(fileName = "WheelOverrideData", menuName = "ScriptableObjects/Vehicle/Wheel override Data")]
public class WheelOverrideData : ScriptableObject
{
    [Flags]
    public enum OverrideCategory
    {
        None = 0,
        Wheels = 1
    }

    [Flags]
    public enum WheelOverrides
    {
        None = 0,
        ForwardFriction = 1,
        SidewaysFriction = 2
    }

    [Flags]
    public enum WheelFrictionOverrides
    {
        None = 0,
        ExtremumSlip = 1,
        ExtremumValue = 2,
        AsymptoteSlip = 4,
        AsymptoteValue = 8,
        Stiffness = 0x10
    }

    public VehicleSettings Settings;
    public OverrideCategory Categories;
    public WheelOverrides WheelFlags;
    public WheelFrictionOverrides ForwardFrictionFlags;
    public WheelFrictionOverrides SidewaysFrictionFlags;
}