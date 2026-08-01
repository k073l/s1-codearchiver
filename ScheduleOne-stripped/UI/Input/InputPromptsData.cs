using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.UI.Input;
[CreateAssetMenu(fileName = "InputPromptsData", menuName = "ScheduleOne/Input/Input Data", order = 1)]
public class InputPromptsData : ScriptableObject
{
    [Header("Properties")]
    public string Id;
    public EInputPromptPosition Position;
    public List<InputPromptsDescriptorData> Descriptors;
    [Header("Animations")]
    public bool EnablePulseAnimation;
}