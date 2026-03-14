using UnityEngine;
using UnityEngine.InputSystem;

namespace ScheduleOne;
[CreateAssetMenu(fileName = "InputDescriptorData", menuName = "ScriptableObjects/InputDescriptorData", order = 1)]
public class InputDescriptorData : ScriptableObject
{
    [SerializeField]
    private InputActionReference inputActionReference;
    [SerializeField]
    private string displayName;
    public InputActionReference InputActionReference => inputActionReference;
    public string DisplayName => displayName;
}