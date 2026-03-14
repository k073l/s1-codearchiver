using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.Settings;
public class SettingsDropdown : MonoBehaviour
{
    public string[] DefaultOptions;
    [SerializeField]
    protected UIPopupSelector _popupSelector;
    private TMP_Dropdown _dropdown;
    protected virtual void Awake();
    protected void SetValueWithoutNotify(int value);
    protected virtual void Start();
    protected virtual void OnValueChanged(int value);
    protected void AddOption(string option);
    protected void AddOptions(List<string> options);
    protected void ClearOptions();
}