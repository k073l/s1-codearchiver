using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Effects;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.Product.Packaging;
using ScheduleOne.StationFramework;
using UnityEngine;

namespace ScheduleOne.Product;
[Serializable]
[CreateAssetMenu(fileName = "ProductDefinition", menuName = "ScriptableObjects/ProductDefinition", order = 1)]
public class ProductDefinition : PropertyItemDefinition, ISaveable
{
    [Header("Product Settings")]
    public List<DrugTypeContainer> DrugTypes;
    public float LawIntensityChange;
    public float BasePrice;
    public float MarketValue;
    public FunctionalProduct FunctionalProduct;
    public int NPCEffectDuration;
    public int PlayerEffectDuration;
    [Range(0f, 1f)]
    public float BaseAddictiveness;
    [Header("Packaging that can be applied to this product. MUST BE ORDERED FROm LOWEST TO HIGHEST QUANTITY")]
    public PackagingDefinition[] ValidPackaging;
    [Header("Product References")]
    public ProductConsumeAnimation ConsumeAnimation;
    public EDrugType DrugType => DrugTypes[0].DrugType;
    public float Price => NetworkSingleton<ProductManager>.Instance.GetPrice(this);
    public List<StationRecipe> Recipes { get; private set; } = new List<StationRecipe>();
    public string SaveFolderName => SaveManager.SanitizeFileName(ID);
    public string SaveFileName => SaveManager.SanitizeFileName(ID);
    public Loader Loader => null;
    public bool ShouldSaveUnderFolder => false;
    public List<string> LocalExtraFolders { get; set; } = new List<string>();
    public List<string> LocalExtraFiles { get; set; } = new List<string>();
    public bool HasChanged { get; set; }

    public override ItemInstance GetDefaultInstance(int quantity = 1);
    public void OnValidate();
    public void Initialize(List<Effect> properties, List<EDrugType> drugTypes);
    public virtual void InitializeSaveable();
    public float GetAddictiveness();
    public void CleanRecipes();
    public void AddRecipe(StationRecipe recipe);
    public virtual void GenerateAppearanceSettings();
    public virtual ProductData GetSaveData();
    public virtual string GetSaveString();
}