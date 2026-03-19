using System;
using UnityEngine;

namespace ScheduleOne.Experimental;
[CreateAssetMenu(fileName = "SkateboardOverrideData", menuName = "ScriptableObjects/Skateboard/Skateboard Override Data")]
public class SkateboardOverrideData : ScriptableObject
{
    [Flags]
    public enum OverrideCategory
    {
        None = 0,
        Turning = 1,
        General = 2,
        Friction = 4,
        Jump = 8,
        Hover = 0x10,
        Pushing = 0x20,
        AirMovement = 0x40
    }

    [Flags]
    public enum TurningOverrides
    {
        None = 0,
        TurnForce = 1,
        TurnChangeRate = 2,
        TurnReturnToRestRate = 4,
        TurnSpeedBoost = 8
    }

    [Flags]
    public enum GeneralOverrides
    {
        None = 0,
        Gravity = 1,
        BrakeForce = 2,
        ReverseTopSpeed_Kmh = 4,
        RotationClampForce = 8
    }

    [Flags]
    public enum FrictionOverrides
    {
        None = 0,
        LongitudinalFrictionMultiplier = 1,
        LateralFrictionForceMultiplier = 2
    }

    [Flags]
    public enum JumpOverrides
    {
        None = 0,
        JumpForce = 1,
        JumpDuration_Min = 2,
        JumpDuration_Max = 4,
        JumpForwardBoost = 8
    }

    [Flags]
    public enum HoverOverrides
    {
        None = 0,
        HoverForce = 1,
        HoverRayLength = 2,
        HoverHeight = 4,
        Hover_P = 8,
        Hover_I = 0x10,
        Hover_D = 0x20
    }

    [Flags]
    public enum PushingOverrides
    {
        None = 0,
        TopSpeed_Kmh = 1,
        PushForceMultiplier = 2,
        PushForceDuration = 4,
        PushDelay = 8
    }

    [Flags]
    public enum AirMovementOverrides
    {
        None = 0,
        AirMovementForce = 1,
        AirMovementJumpReductionDuration = 2
    }

    public SkateboardSettings Settings;
    public OverrideCategory Categories;
    public TurningOverrides TurningFlags;
    public GeneralOverrides GeneralFlags;
    public FrictionOverrides FrictionFlags;
    public JumpOverrides JumpFlags;
    public HoverOverrides HoverFlags;
    public PushingOverrides PushingFlags;
    public AirMovementOverrides AirMovementFlags;
}