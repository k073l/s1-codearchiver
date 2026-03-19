using System;
using UnityEngine;

namespace ScheduleOne.Experimental;
[Serializable]
public class SkateboardSettings
{
    public float TurnForce;
    public float TurnChangeRate;
    public float TurnReturnToRestRate;
    public float TurnSpeedBoost;
    public AnimationCurve TurnForceMap;
    public float Gravity;
    public float BrakeForce;
    public float ReverseTopSpeed_Kmh;
    public float RotationClampForce;
    public bool FrictionEnabled;
    public AnimationCurve LongitudinalFrictionCurve;
    public float LongitudinalFrictionMultiplier;
    public float LateralFrictionForceMultiplier;
    public float JumpForce;
    public float JumpDuration_Min;
    public float JumpDuration_Max;
    public AnimationCurve FrontAxleJumpCurve;
    public AnimationCurve RearAxleJumpCurve;
    public AnimationCurve JumpForwardForceCurve;
    public float JumpForwardBoost;
    public float HoverForce;
    public float HoverRayLength;
    public float HoverHeight;
    public float Hover_P;
    public float Hover_I;
    public float Hover_D;
    [Tooltip("Top speed in m/s")]
    public float TopSpeed_Kmh;
    public float PushForceMultiplier;
    public AnimationCurve PushForceMultiplierMap;
    public float PushForceDuration;
    public float PushDelay;
    public AnimationCurve PushForceCurve;
    public bool AirMovementEnabled;
    public float AirMovementForce;
    public float AirMovementJumpReductionDuration;
    public AnimationCurve AirMovementJumpReductionCurve;
    public float TopSpeed_Ms => TopSpeed_Kmh / 3.6f;

    public SkateboardSettings Clone();
    public SkateboardSettings Blend(SkateboardSettings other, float blendFactor);
}