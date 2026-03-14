using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Audio;
using ScheduleOne.Delivery;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.UI.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.Delivery;
public class DeliveryApp : App<DeliveryApp>
{
    private List<DeliveryShop> deliveryShops;
    public DeliveryStatusDisplay StatusDisplayPrefab;
    [Header("References")]
    public Animation OrderSubmittedAnim;
    public AudioSourceController OrderSubmittedSound;
    public RectTransform StatusDisplayContainer;
    public RectTransform NoDeliveriesIndicator;
    public ScrollRect MainScrollRect;
    public LayoutGroup MainLayoutGroup;
    private List<DeliveryStatusDisplay> statusDisplays;
    private bool started;
    protected override void Awake();
    protected override void Start();
    public override void SetOpen(bool open);
    private void OnMinPass();
    public void RefreshContent(bool keepScrollPosition = true);
    public void PlayOrderSubmittedAnim();
    private void CreateDeliveryStatusDisplay(DeliveryInstance instance);
    private void DeliveryCompleted(DeliveryInstance instance);
    private void SortStatusDisplays();
    private void RefreshNoDeliveriesIndicator();
    public static void RefreshLayoutGroupsImmediateAndRecursive(GameObject root);
    public DeliveryShop GetShop(ShopInterface matchingShop);
    public DeliveryShop GetShop(string shopName);
}