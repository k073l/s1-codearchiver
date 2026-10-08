using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Product.Packaging;
using UnityEngine;

namespace ScheduleOne.Product;
public class ProductIconManager : Singleton<ProductIconManager>
{
    [Serializable]
    public class ProductIcon
    {
        [HideInInspector]
        public string name;
        public string ProductID;
        public string PackagingID;
        public Sprite Icon;
    }

    public const string ProductIconPath;
    private const int RuntimeProductIconSize;
    [SerializeField]
    private List<ProductIcon> icons;
    private List<ProductIcon> _runtimeIcons;
    [Header("Product and packaging")]
    public IconGenerator IconGenerator;
    public ProductDefinition[] Products;
    public PackagingDefinition[] Packaging;
    protected override void Awake();
    protected override void OnDestroy();
    public Sprite GetIcon(string productID, string packagingID, bool ignoreError = false);
    public Sprite GenerateRuntimeIcons(string productID);
    private Texture2D GenerateRuntimeProductTexture(string productID, string packagingID);
    private Texture2D GenerateProductTexture(string productID, string packagingID);
    private void DestroyRuntimeIcons();
}