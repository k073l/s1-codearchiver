using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.FairyLights;
public class FairyLightManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    [Range(0.1f, 10f)]
    private int _pattern;
    [SerializeField]
    [Range(0.1f, 10f)]
    private float _patternSpeed;
    [SerializeField]
    private List<Color> _colours;
    [SerializeField]
    private List<FairyLights> _fairyLights;
    private int _currentPatternIndex;
    private float _patternTimer;
    public int Pattern => _pattern;

    private void Start();
    private void Update();
    public void RegisterFairyLights(FairyLights fairyLights);
    public void UnregisterFairyLights(FairyLights fairyLights);
    public Color GetColor(int index);
}