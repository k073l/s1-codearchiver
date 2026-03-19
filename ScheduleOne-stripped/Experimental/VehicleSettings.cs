using System;

namespace ScheduleOne.Experimental;
[Serializable]
public class VehicleSettings
{
    public WheelFrictionSettings ForwardFriction;
    public WheelFrictionSettings SidewaysFriction;
    public VehicleSettings Clone();
    public VehicleSettings Blend(VehicleSettings other, float t);
}