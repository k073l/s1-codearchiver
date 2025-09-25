using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone;
public class CounterOfferProductSelector : MonoBehaviour
{
    public const int ENTRIES_PER_PAGE;
    public RectTransform Container;
    public InputField SearchBar;
    public RectTransform ProductContainer;
    public Text PageLabel;
    public GameObject ProductEntryPrefab;
    public Action<ProductDefinition> onProductPreviewed;
    public Action<ProductDefinition> onProductSelected;
    private List<RectTransform> productEntries;
    private Dictionary<ProductDefinition, RectTransform> productEntriesDict;
    private string searchTerm;
    private int pageIndex;
    private int pageCount;
    private List<ProductDefinition> results;
    private ProductDefinition lastPreviewedResult;
    public bool IsOpen { get; private set; }

    public void Awake();
    public void Open();
    public void Close();
    private void Update();
    public void SetSearchTerm(string search);
    private void RebuildResultsList();
    private List<ProductDefinition> GetMatchingProducts(string searchTerm);
    private void EnsureAllEntriesExist();
    private void CreateProductEntry(ProductDefinition product);
    public void ChangePage(int change);
    private void SetPage(int page);
    private void ProductHovered(ProductDefinition def);
    private void ProductSelected(ProductDefinition def);
    public bool IsMouseOverSelector();
}