using UnityEngine;

namespace ScheduleOne.Gamepad;
[CreateAssetMenu(fileName = "GamepadPointerData", menuName = "ScheduleOne/Gamepad/Pointer Data", order = 1)]
public class GamepadPointerData : ScriptableObject
{
    public string Id;
    public float Speed;
    public float Acceleration;
    public float Decceleration;
}