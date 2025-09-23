using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Properties;
using UnityEngine;

namespace ScheduleOne.Product;
[Serializable]
[CreateAssetMenu(fileName = "CocaineDefinition", menuName = "ScriptableObjects/Item Definitions/CocaineDefinition", order = 1)]
public class CocaineDefinition : ProductDefinition
{
    [Header("Materials")]
    public Material RockMaterial;
    public CocaineAppearanceSettings AppearanceSettings { get; private set; }

    public override ItemInstance GetDefaultInstance(int quantity = 1);
    public void Initialize(List<ScheduleOne.Properties.Property> properties, List<EDrugType> drugTypes, CocaineAppearanceSettings _appearance);
    public override ProductData GetSaveData();
    public static CocaineAppearanceSettings GetAppearanceSettings(List<ScheduleOne.Properties.Property> properties);
}