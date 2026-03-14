using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using ScheduleOne.PlayerTasks;
using ScheduleOne.Product;
using ScheduleOne.UI.Tooltips;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.ProductManagerApp;
public class ProductAppDetailPanel : MonoBehaviour
{
    public Color AddictionColor_Min;
    public Color AddictionColor_Max;
    [Header("References")]
    public GameObject NothingSelected;
    public GameObject Container;
    public Text NameLabel;
    public InputField ValueLabel;
    public Text SuggestedPriceLabel;
    public Toggle ListedForSale;
    public Text DescLabel;
    public Text[] PropertyLabels;
    public RectTransform Listed;
    public RectTransform Delisted;
    public RectTransform NotDiscovered;
    public RectTransform RecipesLabel;
    public RectTransform[] RecipeEntries;
    public VerticalLayoutGroup LayoutGroup;
    public Scrollbar AddictionSlider;
    public Text AddictionLabel;
    public ScrollRect ScrollRect;
    public ProductDefinition ActiveProduct { get; protected set; }

    public void Awake();
    public void SetActiveProduct(ProductDefinition productDefinition);
    private void Update();
    private void UpdateListed();
    private void UpdatePrice();
    private void ListingToggled();
    private void PriceSubmitted(string value);
}