using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.Settings;
public class SettingsToggle : MonoBehaviour
{
    [SerializeField]
    protected UIToggle uiToggle;
    protected virtual void Awake();
    protected void SetIsOnWithoutNotify(bool value);
    protected virtual void OnValueChanged(bool value);
    private void GetReferences();
}