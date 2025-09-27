using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;

namespace ScheduleOne.Property.Utilities.Water;
public class WaterManager : Singleton<WaterManager>
{
    [Header("Prefabs")]
    [SerializeField]
    protected GameObject waterPipePrefab;
    public static float pricePerL;
    private Dictionary<int, float> usageAtTime;
    private float usageThisMinute;
    protected override void Start();
    private void MinPass();
    private void DayPass();
    public float GetTotalUsage();
    public void ConsumeWater(float litres);
}