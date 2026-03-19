using UnityEngine;

namespace ScheduleOne.Core.Equipping.Framework;
public interface IThirdPersonReferencesProvider
{
    Transform RightHandContainer { get; }

    Transform LeftHandContainer { get; }

    Transform RightHandAlignmentPoint { get; }

    Transform LeftHandAlignmentPoint { get; }

    void SetAnimationBool(string boolName, bool value);
    void SetAnimationTrigger(string triggerName);
}