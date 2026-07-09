using ScheduleOne.DevUtilities;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne;
[RequireComponent(typeof(UIContentPanel))]
public class UIDropdownContent : UIScreen
{
    private TMP_Dropdown _tmpDropdown;
    private Dropdown _legacyDropdown;
    protected override void OnStarted();
    private void Close();
    private void OnDropDownChange(int value);
}