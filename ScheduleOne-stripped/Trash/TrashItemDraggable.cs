using ScheduleOne.DevUtilities;
using ScheduleOne.Dragging;
using ScheduleOne.Equipping;
using ScheduleOne.Interaction;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Trash;
public class TrashItemDraggable : Draggable
{
    private const float InteractionRange;
    private const int InteractionPriority;
    private TrashItem _trashItem;
    protected override void Awake();
    protected override void Hovered();
    protected override void Interacted();
    protected override bool CanStartDrag();
    private bool IsTrashGrabberEquipped(out Equippable_TrashGrabber trashGrabber);
    private bool IsTrashBagEquipped(out TrashBag_Equippable trashBag);
}