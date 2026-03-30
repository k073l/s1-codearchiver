using System;
using System.Collections.Generic;
using ScheduleOne.Effects;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Product;
[Serializable]
[CreateAssetMenu(fileName = "ShroomDefinition", menuName = "ScriptableObjects/Item Definitions/ShroomDefinition", order = 1)]
public class ShroomDefinition : ProductDefinition
{
    [field: SerializeField]
    public Material ShroomMaterial { get; private set; }

    [field: SerializeField]
    public Material BulkMaterial { get; private set; }

    [field: SerializeField]
    public Material EyeballMaterial { get; private set; }
    public ShroomAppearanceSettings AppearanceSettings { get; private set; }

    public override void ValidateDefinition();
    public void Initialize(List<Effect> properties, List<EDrugType> drugTypes, ShroomAppearanceSettings _appearance);
    public override ItemInstance GetDefaultInstance(int quantity = 1);
    public override ProductData GetSaveData();
    public override void GenerateAppearanceSettings();
    private void GenerateMaterials();
    public static ShroomAppearanceSettings GetAppearanceSettings(List<Effect> properties);
}