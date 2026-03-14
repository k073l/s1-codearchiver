using System.Collections.Generic;
using GameKit.Utilities;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Weather;
public class PuddleVolume : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private List<GameObject> _puddleObjs;
    [Header("Settings")]
    [SerializeField]
    private Vector2Int _minMaxPuddlesInVolume;
    [SerializeField]
    private Vector2 _minMaxPuddleDecay;
    [SerializeField]
    private Vector2 _minMaxGrowthRate;
    private float _decayRate;
    private float _growthRate;
    private void Start();
    private void RandomiseActivePuddles();
    private void Update();
    public void UpdateRates(WeatherConditions weatherConditions);
}