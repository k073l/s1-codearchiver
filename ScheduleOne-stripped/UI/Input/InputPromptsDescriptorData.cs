using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScheduleOne.UI.Input;
[CreateAssetMenu(fileName = "InputPromptsData", menuName = "ScheduleOne/Input/Input Descriptor Data", order = 1)]
public class InputPromptsDescriptorData : ScriptableObject
{
    [Header("Properties")]
    public string DisplayName;
    public Color DisplayColor;
    public List<InputActionReference> Actions;
    private void OnValidate();
}