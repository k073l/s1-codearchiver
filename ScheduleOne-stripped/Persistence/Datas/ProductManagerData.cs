using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.Product;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class ProductManagerData : SaveData
{
    public string[] DiscoveredProducts;
    public string[] ListedProducts;
    public NewMixOperation ActiveMixOperation;
    public bool IsMixComplete;
    public MixRecipeData[] MixRecipes;
    public StringIntPair[] ProductPrices;
    public string[] FavouritedProducts;
    public WeedProductData[] CreatedWeed;
    public MethProductData[] CreatedMeth;
    public CocaineProductData[] CreatedCocaine;
    public ShroomProductData[] CreatedShrooms;
    public ContractReceipt[] ContractReceipts;
    public ProductManagerData(string[] discoveredProducts, string[] listedProducts, NewMixOperation activeOperation, bool isMixComplete, MixRecipeData[] mixRecipes, StringIntPair[] productPrices, string[] favouritedProducts, WeedProductData[] createdWeed, MethProductData[] createdMeth, CocaineProductData[] createdCocaine, ShroomProductData[] createdShrooms, ContractReceipt[] receipts);
}