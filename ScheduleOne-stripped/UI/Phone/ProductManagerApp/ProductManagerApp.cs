using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerTasks;
using ScheduleOne.Product;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.ProductManagerApp;
public class ProductManagerApp : App<ProductManagerApp>
{
    [Header("References")]
    public ProductTypeContainer FavouritesContainer;
    public List<ProductTypeContainer> ProductTypeContainers;
    public ProductAppDetailPanel DetailPanel;
    public GameObject EntryPrefab;
    private List<ProductEntry> favouriteEntries;
    private List<ProductEntry> entries;
    private ProductEntry selectedEntry;
    [Header("Gamepad")]
    [SerializeField]
    private UIPanel _favouritesPanel;
    [SerializeField]
    private UIPanel _detailsPanel;
    private bool _returnToPreviousPanel;
    protected override void Awake();
    protected override void Start();
    private void LateUpdate();
    protected override void OnExit(ExitAction exit);
    public virtual void CreateEntry(ProductDefinition definition);
    private void ProductFavourited(ProductDefinition product);
    private void ProductUnfavourited(ProductDefinition product);
    private void CreateFavouriteEntry(ProductDefinition definition);
    private void RemoveFavouriteEntry(ProductDefinition definition);
    private void DelayedRebuildLayout();
    public void SelectProduct(ProductEntry entry);
    public override void SetOpen(bool open);
    private void OnProductListedEvent(ProductDefinition def);
    private void OnPanelChange(UIPanel previous, UIPanel current);
    public void MoveToDetailsPanel();
}