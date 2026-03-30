using ScheduleOne.Delivery;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.UI.Items;
using ScheduleOne.UI.Shop;
using ScheduleOne.UI.Tooltips;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.Delivery;
public class DeliveryStatusDisplay : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private ItemEntryUI ItemEntryPrefab;
    [Header("References")]
    public Text DestinationLabel;
    [SerializeField]
    private Text _loadingDockLabel;
    public Text ShopLabel;
    [SerializeField]
    private Text _shopDescriptionLabel;
    public Image StatusImage;
    public Text StatusLabel;
    public Tooltip StatusTooltip;
    public RectTransform ItemEntryContainer;
    public Animation FlashAnimation;
    public GameObject FlashObject;
    [Header("Settings")]
    [SerializeField]
    private int _maxItemsShown;
    public Color StatusColor_Transit;
    public Color StatusColor_Waiting;
    public Color StatusColor_Arrived;
    [Header("Fonts")]
    [SerializeField]
    private ColorFont _shopTextColorFont;
    public DeliveryInstance DeliveryInstance { get; private set; }

    public void AssignDelivery(DeliveryInstance instance);
    public void RefreshStatus();
    public void Flash();
    private void OnDisable();
}