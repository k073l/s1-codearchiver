using System;
using System.Collections.Generic;
using FishNet;
using FishNet.Object;
using ScheduleOne.Audio;
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
    public float BaseYieldLevel;
    public float BaseQualityLevel;
    public string HarvestTarget;
    [Header("Trash")]
    public TrashItem PlantScrapPrefab;
    [Header("Plant data")]
    public float YieldLevel;
    public float QualityLevel;
    [HideInInspector]
    public List<int> ActiveHarvestables;
    public Action onFullyHarvested;
    public Pot Pot { get; protected set; }
    public float NormalizedGrowthProgress { get; protected set; }
    public bool IsFullyGrown => NormalizedGrowthProgress >= 1f;
    public PlantGrowthStage FinalGrowthStage => GrowthStages[GrowthStages.Length - 1];

    private void Awake();
    public virtual void Initialize(NetworkObject pot, float growthProgress = 0f, float yieldLevel = 0f, float qualityLevel = 0f);
    public virtual void MinPass();
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