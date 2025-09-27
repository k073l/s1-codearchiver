using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.Properties;
using UnityEngine;

namespace ScheduleOne.Product;
public class PropertyUtility : Singleton<PropertyUtility>
{
    [Serializable]
    public class PropertyData
    {
        public EProperty Property;
        public string Name;
        public string Description;
        public Color Color;
    }

    [Serializable]
    public class DrugTypeData
    {
        public EDrugType DrugType;
        public string Name;
        public Color Color;
    }

    public List<PropertyData> PropertyDatas;
    public List<DrugTypeData> DrugTypeDatas;
    public List<ScheduleOne.Properties.Property> AllProperties;
    [Header("Test Mixing")]
    public List<ProductDefinition> Products;
    public List<PropertyItemDefinition> Properties;
    private Dictionary<string, ScheduleOne.Properties.Property> PropertiesDict;
    protected override void Awake();
    protected override void Start();
    public List<ScheduleOne.Properties.Property> GetProperties(int tier);
    public List<ScheduleOne.Properties.Property> GetProperties(List<string> ids);
    public static PropertyData GetPropertyData(EProperty property);
    public static DrugTypeData GetDrugTypeData(EDrugType drugType);
    public static List<Color32> GetOrderedPropertyColors(List<ScheduleOne.Properties.Property> properties);
}