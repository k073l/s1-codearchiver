using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.UI.Tooltips;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Items;
public class FilterConfigPanel : MonoBehaviour
{
    public class SearchCategory
    {
        public class Item
        {
            public ItemDefinition ItemDefinition;
            public RectTransform Entry;
        }

        public EItemCategory Category;
        public RectTransform Container;
        public List<Item> Items;
        public void AddItem(ItemDefinition item, RectTransform entry);
        public void SetSearch(string search);
        public Item GetItem(string itemID);
    }

    public GameObject ItemEntryPrefab;
    public GameObject CategoryPrefab;
    public GameObject SearchItemPrefab;
    [Header("References")]
    public RectTransform Rect;
    public GameObject Container;
    public Button TypeButton_None;
    public Button TypeButton_Whitelist;
    public Button TypeButton_Blacklist;
    public TextMeshProUGUI TypeLabel;
    public TextMeshProUGUI ListLabel;
    public RectTransform ListContainer;
    public GameObject ListBlocker;
    public Button[] QualityButtons;
    public ScrollRect ListScrollRect;
    public RectTransform Dropdown;
    public Button CopyButton;
    public Button PasteButton;
    public Button ApplyToSiblingsButton;
    public Button ClearButton;
    [Header("Search")]
    public RectTransform SearchContainer;
    public TMP_InputField SearchInput;
    public RectTransform CategoryContainer;
    private bool mouseUp;
    private List<SearchCategory> searchCategories;
    private List<RectTransform> itemEntries;
    private static SlotFilter copiedFilter;
    public bool IsOpen { get; private set; }
    public ItemSlot OpenSlot { get; private set; }

    private void Awake();
    private void Start();
    private void Exit(ExitAction exit);
    private void Update();
    public void Open(ItemSlotUI ui);
    public void Close();
    private void UpdateSearch();
    public void FilterModeSelected(int filterType);
    public void FilterModeSelected(SlotFilter.EType filterType);
    public void QualitySelected(int quality);
    public void QualitySelected(EQuality quality);
    public void AddClicked();
    public void CopyClicked();
    public void PasteClicked();
    public void ApplyToSiblingsClicked();
    public void ClearClicked();
    public void ToggleDropdown();
    public void OpenDropdown();
    public void CloseDropdown();
    private void ItemClicked(string itemID);
    private void AddItem(string itemID);
    private void RemoveItem(string itemID);
    private void RefreshDisplay();
    private bool IsMouseOverPanel();
    private bool IsMouseOverSearch();
    private bool IsMouseOverDropdown();
    private SearchCategory GetSearchCategory(EItemCategory category);
    private void OpenSearch();
    private void CloseSearch();
    private void SearchChanged(string search);
    private void RefreshSearchResults();
}