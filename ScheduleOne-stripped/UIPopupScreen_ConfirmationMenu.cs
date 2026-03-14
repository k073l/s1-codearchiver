using System;
using System.Collections;
using ScheduleOne.DevUtilities;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne;
public class UIPopupScreen_ConfirmationMenu : UIPopupScreen
{
    [SerializeField]
    private TMP_Text titleText;
    [SerializeField]
    private TMP_Text messageText;
    [SerializeField]
    private UISelectable confirmButton;
    [SerializeField]
    private UISelectable cancelButton;
    [SerializeField]
    private Canvas canvas;
    public override void Close();
    private void Open();
    public override void Open(params object[] args);
    private IEnumerator RegisterInput(Action onConfirm, Action onCancel);
    private void SelectPanel(UISelectable selectable);
}