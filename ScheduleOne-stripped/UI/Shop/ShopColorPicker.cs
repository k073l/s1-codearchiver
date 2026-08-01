using System;
using System.Collections.Generic;
using ScheduleOne.Clothing;
using ScheduleOne.DevUtilities;
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
    public UIScreen Screen;
    public UIPanel Panel;
    public UnityEvent<EClothingColor> onColorPicked;
    private List<UISelectable> colorButtons;
    public bool IsOpen => ((Component)this).gameObject.activeInHierarchy;

    public void Awake();
    private void ColorPicked(EClothingColor color);
    public void Open(ItemDefinition item);
    public void Close();
    private void ColorHovered(EClothingColor color);
}