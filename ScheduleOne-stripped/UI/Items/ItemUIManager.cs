using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.UI.Items;
public class ItemUIManager : Singleton<ItemUIManager>
{
    private static readonly float[] CASH_DRAG_AMOUNTS;
    private static readonly float[] CASH_DRAG_THRESHOLDS;
    [Header("References")]
    public Canvas Canvas;
    public RectTransform CashDragAmountContainer;
    public RectTransform InputsContainer;
    public ItemInfoPanel InfoPanel;
    public RectTransform ItemQuantityPrompt;
    public Animation CashSlotHintAnim;
    public CanvasGroup CashSlotHintAnimCanvasGroup;
    public FilterConfigPanel FilterConfigPanel;
    [Header("Prefabs")]
    public ItemSlotUI ItemSlotUIPrefab;
    public ItemUI DefaultItemUIPrefab;
    public ItemSlotUI HotbarSlotUIPrefab;
    private ItemSlotUI draggedSlot;
    private Vector2 mouseOffset;
    private int draggedAmount;
    private RectTransform tempIcon;
    private List<GraphicRaycaster> _raycasters;
    private bool isDraggingCash;
    private float draggedCashAmount;
    private List<ItemSlot> PrimarySlots;
    private List<ItemSlot> SecondarySlots;
    private bool customDragAmount;
    private Coroutine quantityChangePopRoutine;
    public UnityEvent onDragStart;
    public UnityEvent onItemMoved;
    private bool canControllerQuickMove;
    private bool isInfoPanelToggledOn;
    public bool DraggingEnabled { get; protected set; }
    public ItemSlotUI HoveredSlot { get; protected set; }
    public bool QuickMoveEnabled { get; protected set; }

    protected override void Awake();
    private void OnInputDeviceChanged(GameInput.InputDeviceType type);
    public void ControllerHighlightSlot(ItemSlotUI itemSlot);
    public void ControllerToggleTooltip();
    public void ControllerGrabAllSlot();
    public void ControllerQuickMoveSlot();
    public void ControllerDragAddQuantity();
    public void ControllerDragSubtractQuantity();
    public void ControllerDiscardSlot();
    private void TryOpenInfoPanel(ItemSlotUI itemSlot);
    private void TryCloseInfoPanel();
    private void UpdateControllerTooltip();
    protected virtual void Update();
    public void AddRaycaster(GraphicRaycaster raycaster);
    protected virtual void LateUpdate();
    private void UpdateCashDragSelectorUI();
    private void UpdateCashDragAmount(CashInstance instance);
    private void AddCashAmount(CashInstance instance, bool wrapAround = false);
    private void SubtractCashAmount(CashInstance instance, bool wrapAround = false);
    public void SetDraggingEnabled(bool enabled, bool modifierPromptsVisible = true);
    public void EnableQuickMove(List<ItemSlot> primarySlots, List<ItemSlot> secondarySlots);
    private List<ItemSlot> GetQuickMoveSlots(ItemSlot sourceSlot);
    public void DisableQuickMove();
    private ItemSlotUI GetHoveredItemSlot();
    private ItemDefinitionInfoHoverable GetHoveredItemInfo();
    private void SlotClicked(ItemSlotUI ui);
    private void StartDragCash();
    private void EndDrag();
    private void SetDraggedAmount(int amount);
    private void EndCashDrag();
    public bool CanDragFromSlot(ItemSlotUI slotUI);
    public bool CanCashBeDraggedIntoSlot(ItemSlotUI ui);
}