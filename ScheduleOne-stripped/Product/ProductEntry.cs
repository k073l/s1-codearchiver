using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Events;
using ScheduleOne.UI.Phone.ProductManagerApp;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.Product;
public class ProductEntry : MonoBehaviour
{
    public Color SelectedColor;
    public Color DeselectedColor;
    public Color FavouritedColor;
    public Color UnfavouritedColor;
    [Header("References")]
    public Button Button;
    public Image Frame;
    public Image Icon;
    public RectTransform Tick;
    public RectTransform Cross;
    public EventTrigger Trigger;
    public Button FavouriteButton;
    public Button ListingButton;
    public Button MoveToDetailsButton;
    public Image FavouriteIcon;
    public GameObject Outline;
    public UnityEvent onHovered;
    private bool destroyed;
    private Action<ProductDefinition> onListed;
    private BasicEvent _onMovedToDetails;
    public ProductDefinition Definition { get; private set; }

    public void Initialize(ProductDefinition definition);
    public void Destroy();
    private void OnDestroy();
    public void Clicked();
    public void FavouriteClicked();
    private void ProductListedOrDelisted(ProductDefinition def);
    public void UpdateListed();
    private void ProductFavouritedOrUnFavourited(ProductDefinition def);
    public void UpdateFavourited();
    public void UpdateDiscovered(ProductDefinition def);
    public void SetSelection(bool value);
    private void ListProductEvent();
    public void SubscribeToListed(Action<ProductDefinition> callback);
    public void UnsubscribeFromListed(Action<ProductDefinition> callback);
    public void SubscribeToMoveToDetails(BasicEvent callback);
    public void UnsubscribeFromMoveToDetails(BasicEvent callback);
}