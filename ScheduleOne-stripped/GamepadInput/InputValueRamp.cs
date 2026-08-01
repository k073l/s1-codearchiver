using UnityEngine;

namespace ScheduleOne.GamepadInput;
public class InputValueRamp : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float _defaultIncrement;
    [SerializeField]
    private int _defaultDirection;
    [SerializeField]
    private Vector2 _minMaxIncrementRate;
    [SerializeField]
    private float _timeToMaxSpeed;
    [SerializeField]
    private AnimationCurve _rampCurve;
    private float _increment;
    private int _direction;
    private float _time;
    private float _holdTime;
    private float _incrementRate;
    private bool _isActive;
    private event ValueChange _onValueChange;
    private void Start();
    private void Update();
    public void Initialise(float increment, int direction);
    public void Begin();
    private void Run();
    public void End();
    public void SubscribeToOnValueChange(ValueChange callback);
    public void UnsubscribeFromOnValueChange(ValueChange callback);
}