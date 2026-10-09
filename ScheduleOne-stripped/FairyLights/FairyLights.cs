using System.Collections.Generic;
using ScheduleOne.Cabling;
using UnityEngine;

namespace ScheduleOne.FairyLights;
public class FairyLights : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private FlexibleCable _cable;
    [SerializeField]
    private LightGlobe _globePrefab;
    [Header("Settings")]
    [SerializeField]
    [Range(1f, 5f)]
    private int _pointsPerGlobe;
    [SerializeField]
    [Range(0f, 5f)]
    private int _lightsPerGlobe;
    [SerializeField]
    [Range(0.01f, 10f)]
    private float _lightRadius;
    [Header("Debugging")]
    [SerializeField]
    private bool _showGizmos;
    [SerializeField]
    private FairyLightManager _debugManager;
    private FairyLightManager _manager;
    private GameObject[] _containers;
    private List<LightGlobe> _globes;
    private int _pattern;
    private int _lightCount;
    public int Initialise(FairyLightManager manager, int startIndex, int pattern, int lightCount);
    public void UpdateLights(int activePatternIndex);
    public void SetLights(int activeIndex);
    public void OnDrawGizmos();
}