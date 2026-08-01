using UnityEngine;

namespace ScheduleOne.Gamepad;
public interface IGamepadPointerHandler
{
    void Initialise(GamepadPointer manager, float maxFriction, AnimationCurve frictionCurve);
    Vector2 GetPosition(Vector2 rawInput, Vector2 pointerPosition, float speed, bool isAimAssistActive);
}