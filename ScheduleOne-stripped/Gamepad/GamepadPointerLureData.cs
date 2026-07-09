using UnityEngine;

namespace ScheduleOne.Gamepad;
[CreateAssetMenu(fileName = "GamepadPointerLureData", menuName = "ScheduleOne/Gamepad/Pointer Lure Data", order = 1)]
public class GamepadPointerLureData : ScriptableObject
{
    public string Id;
    public float Radius;
    public float InteractionRadius;
    [Range(0f, 1f)]
    public float Strength;
}