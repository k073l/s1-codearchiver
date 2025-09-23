using System.Collections.Generic;
using ScheduleOne.ItemFramework;
using ScheduleOne.Product;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Items;
public class ProductItemInfoContent : QualityItemInfoContent
{
    public List<TextMeshProUGUI> PropertyLabels;
    public override void Initialize(ItemInstance instance);
    public override void Initialize(ItemDefinition definition);
}