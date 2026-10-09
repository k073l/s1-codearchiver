using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.FairyLights;
public class LightGlobe : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private List<MeshRenderer> _globeRenderers;
    [SerializeField]
    private Light _globeLight;
    private MaterialPropertyBlock[] _mpbs;
    public Light Light => _globeLight;

    public void SetProperties(Color color, int patternIndex);
    public void UpdateLight(int activePatternIndex);
    public void SetLightActive(bool isActive);
    public void SetLight(bool isActive, Color color, float radius);
}