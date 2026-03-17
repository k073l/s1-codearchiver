using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne;
public class UISelectable_OSK : UISelectable
{
    protected override void Awake();
    private void ShowOSK();
    private void OnSubmit(string text);
    protected override bool DeselectOnPointerExit();
    private void OnCancel();
}