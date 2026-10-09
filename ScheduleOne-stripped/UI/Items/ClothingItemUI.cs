using ScheduleOne.Clothing;
using ScheduleOne.Configuration;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Items;
public class ClothingItemUI : ItemUI
{
    public Image ClothingTypeIcon;
    private ClothingConfiguration _clothingConfiguration;
    public override void Setup(ItemInstance item);
    public override void Destroy();
    private void OnClothingConfigChanged(BaseConfiguration config);
    public override void UpdateUI();
}