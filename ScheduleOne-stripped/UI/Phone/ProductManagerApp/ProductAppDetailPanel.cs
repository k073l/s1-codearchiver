using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GamepadInput;
using ScheduleOne.Money;
using ScheduleOne.PlayerTasks;
using ScheduleOne.Product;
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
    public Toggle FavouriteProduct;
    public Text DescLabel;
    public Text[] PropertyLabels;
    public RectTransform RecipesLabel;
    public ProductRecipe[] RecipeEntries;
    public Scrollbar AddictionSlider;
    public Text AddictionLabel;
    [SerializeField]
    private Transform _addButton;
    [SerializeField]
    private Transform _removeButton;
    [Header("Input")]
    [SerializeField]
    private InputValueRamp _inputValueRamp;
    public ProductDefinition ActiveProduct { get; protected set; }

    public void Awake();
    private void OnDestroy();
    public void SetActiveProduct(ProductDefinition productDefinition);
    private void Update();
    public void UpdateListed();
    public void UpdateFavourite();
    private void UpdatePrice();
    private void ListingToggled();
    private void OnInputChange(GameInput.InputDeviceType device);
    private void AdjustPrice(float change);
    private void PriceSubmitted(string value);
    private void OnToggleFavourited(bool value);
}