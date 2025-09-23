using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Properties;
using UnityEngine;

namespace ScheduleOne.Product;
[Serializable]
[CreateAssetMenu(fileName = "MethDefinition", menuName = "ScriptableObjects/Item Definitions/MethDefinition", order = 1)]
public class MethDefinition : ProductDefinition
{
    public Material CrystalMaterial;
    [ColorUsage(true, true)]
    [SerializeField]
    public Color TintColor;
    public MethAppearanceSettings AppearanceSettings { get; private set; }

    public override ItemInstance GetDefaultInstance(int quantity = 1);
    public void Initialize(List<ScheduleOne.Properties.Property> properties, List<EDrugType> drugTypes, MethAppearanceSettings _appearance);
    public override ProductData GetSaveData();
    public static MethAppearanceSettings GetAppearanceSettings(List<ScheduleOne.Properties.Property> properties);
}