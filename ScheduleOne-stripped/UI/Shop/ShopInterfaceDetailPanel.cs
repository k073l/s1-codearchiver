using System.Collections;
using ScheduleOne.DevUtilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Shop;
public class ShopInterfaceDetailPanel : MonoBehaviour
{
    [Header("References")]
    public RectTransform Panel;
    public VerticalLayoutGroup LayoutGroup;
    public TextMeshProUGUI DescriptionLabel;
    public TextMeshProUGUI UnlockLabel;
    private ListingUI _listingUI;
    private void Awake();
    public void Open(ListingUI listingUI);
    public bool AnythingToDisplay(ShopListing listing);
    private void LateUpdate();
    private void Position();
    public void Close();
}