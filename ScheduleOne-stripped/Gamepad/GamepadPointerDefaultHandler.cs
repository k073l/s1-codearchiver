using UnityEngine;

namespace ScheduleOne.Gamepad;
public class GamepadPointerDefaultHandler : IGamepadPointerHandler
{
    private GamepadPointer _manager;
    private float _maxFriction;
    private AnimationCurve _frictionCurve;
    public void Initialise(GamepadPointer manager, float maxFriction, AnimationCurve frictionCurve);
    public Vector2 GetPosition(Vector2 rawInput, Vector2 pointerPosition, float speed, bool isAimAssistActive);
    private void CalculateSteering(Vector2 pointerPosition, Vector2 currentDir, float rawInputMagnitude, out Vector2 steeredDir, out float frictionMultiplier, bool isAimAssistActive);
}