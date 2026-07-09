using ScheduleOne.DevUtilities;
using ScheduleOne.UI;
using ScheduleOne.UI.Input;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ScheduleOne.CustomUI;
public class UISelectable_ItemSlot : UISelectable
{
    private ItemSlotUI _itemSlotUI;
    [SerializeField]
    private InputPromptsData _itemSlotInputPrompts;
    protected override void Awake();
    protected override bool CanBeSelectedWhileDraggingItem();
    public override void OnSelect(BaseEventData eventData);
    public override void OnDeselect(BaseEventData eventData);
    private bool CanInteractWithSlot();
}