using System;
using ScheduleOne.DevUtilities;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne;
public class UIPopupSelector : UIOption
{
    [SerializeField]
    private TextMeshProUGUI currentOptionNameText;
    public UnityEvent<UIPopupScreen_ContextMenu.ContextMenuOption> OnChanged;
    private UIPopupScreen_ContextMenu.ContextMenuOption[] options;
    private int currentIndex;
    public int GetOptionCount();
    protected override void Awake();
    private void OpenPopup();
    private void ClosePopup(int selectedIndex);
    public void SetCurrentOptionWithoutNotify(int index);
    private void UpdateCurrentOptionText();
    public void AddOption(UIPopupScreen_ContextMenu.ContextMenuOption option);
    public void AddOptions(UIPopupScreen_ContextMenu.ContextMenuOption[] newOptions);
    public void ClearOptions();
    private void ClampCurrentIndex();
    public void SetOptions(UIPopupScreen_ContextMenu.ContextMenuOption[] newOptions, int defaultIndex = 0);
}