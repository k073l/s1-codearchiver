using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Items;
public class ItemSlotFilterButton : MonoBehaviour
{
    public ItemSlotUI ItemSlotUI;
    public Button Button;
    public Image IconImage;
    public Image SpotImage;
    public Image[] FilterItemImages;
    public TextMeshProUGUI FilterMoreItemsLabel;
    public ItemSlot AssignedSlot { get; protected set; }

    private void Awake();
    public void AssignSlot(ItemSlot slot);
    public void UnassignSlot();
    public void Clicked();
    private void RefreshAppearance();
}