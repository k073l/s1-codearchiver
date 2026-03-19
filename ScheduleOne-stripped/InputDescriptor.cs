using UnityEngine;

namespace ScheduleOne;
public class InputDescriptor : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Assign a InputDescriptorData scriptableObject. The scriptableObject should be placed in Assets/CustomUI/InputDescriptor")]
    private InputDescriptorData data;
    [SerializeField]
    [Tooltip("Assign the UITrigger component that suppose to detect and receive input when the input action from the InputDescriptorData is fired")]
    private UITrigger uiTrigger;
    public void DetectTriggerInput();
    public void OnReset();
    public bool GetInputTriggered();
    public T GetInputValue<T>()
        where T : struct;
}