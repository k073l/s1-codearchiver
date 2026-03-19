using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Settings;
public class SettingsToggle : MonoBehaviour
{
    protected Toggle toggle;
    [SerializeField]
    protected UIToggle uiToggle;
    protected virtual void Awake();
    protected void SetIsOnWithoutNotify(bool value);
    protected virtual void OnValueChanged(bool value);
}