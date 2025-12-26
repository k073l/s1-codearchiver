using ScheduleOne.ItemFramework;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Items;
public class WaterContainerUI : ItemUI
{
    protected WaterContainerInstance wcInstance;
    public Text AmountLabel;
    public override void Setup(ItemInstance item);
    public override void UpdateUI();
}