using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Levelling;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Map;
public class Map : Singleton<Map>
{
    public const EMapRegion FINAL_REGION;
    public bool UNLOCK_ALL_REGIONS;
    public MapRegionData[] Regions;
    [Header("References")]
    public PoliceStation PoliceStation;
    public MedicalCentre MedicalCentre;
    public Transform TreeBounds;
    protected override void Awake();
    protected override void Start();
    private void OnRankUp(FullRank old, FullRank newRank);
    public MapRegionData GetRegionData(EMapRegion region);
    public List<EMapRegion> GetUnlockedRegions();
    public EMapRegion GetRegionFromPosition(Vector3 position);
}