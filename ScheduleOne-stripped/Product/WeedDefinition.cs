using System;
using System.Collections.Generic;
using ScheduleOne.Effects;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using UnityEngine;

namespace ScheduleOne.Product;
[Serializable]
[CreateAssetMenu(fileName = "WeedDefinition", menuName = "ScriptableObjects/Item Definitions/WeedDefinition", order = 1)]
public class WeedDefinition : ProductDefinition
{
    [Header("Weed Materials")]
    public Material MainMat;
    public Material SecondaryMat;
    public Material LeafMat;
    public Material StemMat;
    private WeedAppearanceSettings appearance;
    public override ItemInstance GetDefaultInstance(int quantity = 1);
    public void Initialize(List<Effect> properties, List<EDrugType> drugTypes, WeedAppearanceSettings _appearance);
    public override ProductData GetSaveData();
    public override void GenerateAppearanceSettings();
    private void ApplyAppearanceSettings();
    public static WeedAppearanceSettings GetAppearanceSettings(List<Effect> properties);
    public Material GetMaterial(WeedAppearanceSettings.EWeedAppearanceType type);
}