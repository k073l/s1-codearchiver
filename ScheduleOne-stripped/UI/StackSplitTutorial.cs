using ScheduleOne.DevUtilities;
using ScheduleOne.UI.Items;
using UnityEngine;

namespace ScheduleOne.UI;
public class StackSplitTutorial : MonoBehaviour
{
    private ItemSlotUI _slotUI;
    public void Open(ItemSlotUI slotUI);
    private void OnSlotDragStart(ItemSlotUI slotUI);
    public void Close();
}