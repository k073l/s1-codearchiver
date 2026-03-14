using System;
using System.Collections.Generic;
using FishNet;
using FishNet.Object;
using ScheduleOne.Audio;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Trash;
using UnityEngine;

namespace ScheduleOne.Growing;
public abstract class Plant : MonoBehaviour
{
    public const float BaseQualityLevel;
    [Header("References")]
    public Transform VisualsContainer;
    public PlantGrowthStage[] GrowthStages;
    public Collider Collider;
    public AudioSourceController SnipSound;
    public AudioSourceController DestroySound;
    public ParticleSystem FullyGrownParticles;
    public Transform HarvestLabelPositionTransform;
    [Header("Settings")]
    public SeedDefinition SeedDefinition;
    public int GrowthTime;
    public int BaseYieldQuantity;
    public string HarvestTarget;
    [Header("Trash")]
    public TrashItem PlantScrapPrefab;
    [HideInInspector]
    public List<int> ActiveHarvestables;
    public Action onFullyHarvested;
    public Pot Pot { get; protected set; }
    public float NormalizedGrowthProgress { get; protected set; }
    public bool IsFullyGrown => NormalizedGrowthProgress >= 1f;
    public float YieldMultiplier { get; private set; } = 1f;
    public float QualityLevel { get; private set; } = 0.5f;
    public PlantGrowthStage FinalGrowthStage => GrowthStages[GrowthStages.Length - 1];

    private void Awake();
    public virtual void Initialize(NetworkObject pot, float growthProgress);
    public virtual void MinPass(int mins);
    public void AdditiveApplied(AdditiveDefinition additive, bool isInitialApplication);
    public virtual void SetNormalizedGrowthProgress(float progress);
    protected virtual void UpdateVisuals();
    public virtual void SetHarvestableActive(int index, bool active);
    private void OnFullyHarvested();
    public bool IsHarvestableActive(int index);
    private void GrowthDone();
    private List<int> GenerateUniqueIntegers(int min, int max, int count);
    public void SetVisible(bool vis);
    public virtual ItemInstance GetHarvestedProduct(int quantity = 1);
    public PlantData GetPlantData();
}