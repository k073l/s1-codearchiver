using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.Items;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class ItemSlotUI : MonoBehaviour
{
    public Color32 normalColor;
    public Color32 highlightColor;
    [HideInInspector]
    public bool IsBeingDragged;
    [Header("Settings")]
    [SerializeField]
    private bool _playBopAnimation;
    [Header("References")]
    public RectTransform Rect;
    public Image Background;
    public GameObject LockContainer;
    public RectTransform ItemContainer;
    public ItemSlotFilterButton FilterButton;
    public Animation BopAnimation;
    [Header("Controller Support")]
    public UITrigger CmdQuickMove;
    public UITrigger CmdGrabAll;
    public UITrigger CmdQtyAdd;
    public UITrigger CmdQtySubtract;
    public UITrigger CmdToggleTooltip;
    public UITrigger CmdDiscardItem;
    private int _lastQuantity;
    private bool _slotBopQueued;
    public ItemSlot assignedSlot { get; protected set; }
    public ItemUI ItemUI { get; protected set; }

    private void Awake();
    public virtual void AssignSlot(ItemSlot s);
    public virtual void ClearSlot();
    protected virtual void LateUpdate();
    public void OnDestroy();
    public virtual void UpdateUI();
    public void SetHighlighted(bool h);
    public void SetNormalColor(Color color);
    public void SetHighlightColor(Color color);
    private void Lock();
    private void Unlock();
    public void SetLockVisible(bool vis);
    public RectTransform DuplicateIcon(Transform parent, int overriddenQuantity = -1);
    public void SetVisible(bool shown);
    public void OverrideDisplayedQuantity(int quantity);
    private void AssignControllerCommands();
    private void UnassignControllerCommands();
    private void WrapCmdQuickMove();
    private void WrapCmdGrabAll();
    private void WrapCmdQtyAdd();
    private void WrapCmdQtySubtract();
    private void WrapCmdToggleTooltip();
    private void WrapCmdDiscardItem();
    public void ControllerSelect(bool isSelected);
    private void OnItemSlotDataChanged();
    private void CheckSlotBop();
}