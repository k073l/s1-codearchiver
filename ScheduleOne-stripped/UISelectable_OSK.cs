using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne;
public class UISelectable_OSK : UISelectable
{
    [Header("Specify a text component to pull the input description from, otherwise it will use the default InputDescription string")]
    public TextMeshProUGUI InputDescriptionSource;
    public string InputDescription;
    private TMP_InputField tmpInputField;
    private InputField legacyInputField;
    protected override void Awake();
    private void ShowOSK();
    private void OnSubmit(string text);
    protected override bool DeselectOnPointerExit();
    public void OnTriggered();
    private void OnCancel();
    private void OnSelect();
    private void UpdateCaret();
}