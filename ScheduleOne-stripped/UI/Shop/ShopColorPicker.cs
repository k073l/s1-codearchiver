using System;
using ScheduleOne.Clothing;
using ScheduleOne.ItemFramework;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.UI.Shop;
public class ShopColorPicker : MonoBehaviour
{
    public Image AssetIconImage;
    public TextMeshProUGUI ColorLabel;
    public RectTransform ColorButtonParent;
    public GameObject ColorButtonPrefab;
    public UnityEvent<EClothingColor> onColorPicked;
    public bool IsOpen => ((Component)this).gameObject.activeInHierarchy;

    public void Start();
    private void ColorPicked(EClothingColor color);
    public void Open(ItemDefinition item);
    public void Close();
    private void ColorHovered(EClothingColor color);
}