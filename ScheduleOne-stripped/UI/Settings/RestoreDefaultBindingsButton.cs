using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Settings;
public class RestoreDefaultBindingsButton : MonoBehaviour
{
    public enum EType
    {
        KeyboardMouse,
        Gamepad
    }

    [SerializeField]
    private EType type;
    [SerializeField]
    private Button button;
    private void Awake();
    private void OnButtonPressed();
}