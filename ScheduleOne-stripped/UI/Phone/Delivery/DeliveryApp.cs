using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Audio;
using ScheduleOne.Configuration;
using ScheduleOne.Delivery;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Money;
using ScheduleOne.UI.Shop;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.Delivery;
public class DeliveryApp : App<DeliveryApp>
{
    [Serializable]
    public class DeliveryShopElement
    {
        public DeliveryShop Shop;
        public Button Button;
    }

    private List<DeliveryShop> deliveryShops;
    public DeliveryStatusDisplay StatusDisplayPrefab;
    [Header("References")]
    public Animation OrderSubmittedAnim;
    public AudioSourceController OrderSubmittedSound;
    public RectTransform StatusDisplayContainer;
    public GameObject NoDeliveriesIndicator;
    public GameObject NoPastDeliveriesIndicator;
    public ScrollRect MainScrollRect;
    public LayoutGroup MainLayoutGroup;
    [Header("Components")]
    [SerializeField]
    private DeliveryReceiptDisplay _deliveryReceiptPrefab;
    public RectTransform PastDeliveriesContainer;
    [Header("References")]
    [SerializeField]
    private TabController _tabController;
    [SerializeField]
    private CanvasGroup shopListCanvas;
    [SerializeField]
    private CanvasGroup orderCanvas;
    [SerializeField]
    private List<DeliveryShopElement> _shopElements;
    [Header("Settings")]
    [SerializeField]
    private float shopPanelWidth;
    [SerializeField]
    private float shopTransitionDuration;
    private List<DeliveryStatusDisplay> statusDisplays;
    private DeliveryReceiptDisplay[] _pastDeliveries;
    private bool started;
    private List<RectTransform> _shopPanels;
    private List<Vector2> _shopPanelInitialAnchors;
    private Coroutine _shopTransitionCoroutine;
    protected override void Awake();
    protected override void Start();
    public void OpenShop(DeliveryShop shop);
    public void CloseShop(DeliveryShop shop);
    private IEnumerator DoShopTransitionRoutine(float duration, int direction, List<RectTransform> panels, Action onComplete);
    public override void Exit(ExitAction exit);
    private void SetCanvasInteraction(CanvasGroup canvas, bool interactable);
    public override void SetOpen(bool open);
    private void OnMinPass();
    public void RefreshContent(bool keepScrollPosition = true);
    public void OnSubmitOrder(DeliveryShop shop);
    public void PlayOrderSubmittedAnim();
    public void Reorder(DeliveryReceipt receipt);
    public bool CanReorder(DeliveryReceipt receipt, out string reason);
    public float GetDeliveryCost(DeliveryReceipt receipt);
    private void CreateDeliveryStatusDisplay(DeliveryInstance instance);
    private void DeliveryCompleted(DeliveryInstance instance);
    private void SortStatusDisplays();
    private void RefreshNoDeliveriesIndicator();
    public static void RefreshLayoutGroupsImmediateAndRecursive(GameObject root);
    public DeliveryShop GetShop(string shopName);
    public void SetIsAvailable(ShopInterface matchingShop, bool available);
    private void OnTabChange(int index);
    private void UpdatePastDeliveries();
    private bool IsValidReceipt(DeliveryReceipt receipt);
    private void RefreshNotifications();
}