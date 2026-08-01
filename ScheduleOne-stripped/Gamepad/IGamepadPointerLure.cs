using UnityEngine;

namespace ScheduleOne.Gamepad;
public interface IGamepadPointerLure
{
    GamepadPointerLureData Data { get; }

    bool IsActive { get; }

    bool RegisterDefaultLureWhenEmpty { get; }

    Vector3 Position { get; }

    Vector3 Offset { get; }

    void SetActive(bool value);
}