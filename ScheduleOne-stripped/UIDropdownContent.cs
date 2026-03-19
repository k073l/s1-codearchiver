using ScheduleOne.DevUtilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne;
[RequireComponent(typeof(UIContentPanel))]
public class UIDropdownContent : UIScreen
{
    protected override void OnStarted();
    private void Close();
}