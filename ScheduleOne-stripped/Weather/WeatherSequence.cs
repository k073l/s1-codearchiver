using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Weather;
[CreateAssetMenu(fileName = "WeatherSequence", menuName = "ScriptableObjects/Weather/Weather Sequence")]
public class WeatherSequence : ScriptableObject
{
    [Serializable]
    public class SequenceItem
    {
        public WeatherVolume Volume;
        public int ActiveTime;
        public int TransitionInTime;
    }

    public enum TimeReference
    {
        StartOfDay,
        OnInitialisation,
        Custom
    }

    [Header("Settings")]
    [SerializeField]
    private string _id;
    [SerializeField]
    [Range(0f, 1f)]
    private float _chanceToOccur;
    [SerializeField]
    private int _startTime;
    [SerializeField]
    private TimeReference _timeReference;
    [SerializeField]
    private List<SequenceItem> _weatherVolumes;
    public string Id => _id;
    public List<SequenceItem> WeatherVolumes => _weatherVolumes;
    public TimeReference TimeRef => _timeReference;
    public int StartTime => _startTime;
}