using ScheduleOne.Misc;
using UnityEngine;

namespace ScheduleOne.Map.Infrastructure;
public class TrafficLight : MonoBehaviour
{
    public enum State
    {
        Red,
        Orange,
        Green
    }

    [SerializeField]
    private ToggleableLight _redLight;
    [SerializeField]
    private ToggleableLight _orangeLight;
    [SerializeField]
    private ToggleableLight _greenLight;
    private State _state;
    public State CurrentState { get; set; }

    protected virtual void ApplyState();
}