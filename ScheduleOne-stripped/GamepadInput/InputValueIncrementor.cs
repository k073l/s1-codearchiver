using UnityEngine;

namespace ScheduleOne.GamepadInput;
public class InputValueIncrementor : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private InputValueRamp _inputValueRamp;
    [Header("Settings")]
    [SerializeField]
    private float _singleValue;
    [SerializeField]
    private float _multiValue;
    public void IncrementSingle();
    public void IncrementMulti();
    public void DecrementSingle();
    public void DecrementMulti();
    private void Set(float value, int direction);
    public void End();
}