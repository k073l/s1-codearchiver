using ScheduleOne.Clothing;
using ScheduleOne.Configuration;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Items;
public class ClothingItemUI : ItemUI
{
    public Image ClothingTypeIcon;
    private ClothingConfiguration _clothingConfiguration;
    private void Awake();
    private void OnDestroy();
    private void OnClothingConfigChanged(BaseConfiguration config);
    public override void UpdateUI();
}