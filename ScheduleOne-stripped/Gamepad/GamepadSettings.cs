using System;

namespace ScheduleOne.Gamepad;
[Serializable]
public class GamepadSettings
{
    public float GamepadCameraSensitivity;
    public float PointerSensitivity;
    public const float DEFAULT_SENSITIVITY;
    public const float MIN_SENSITIVITY;
    public const float MAX_SENSITIVITY;
}