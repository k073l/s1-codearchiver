using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Weather;
public class WorldEnclosure : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private List<BasicEnclosure> _enclosures;
    private List<BasicEnclosure> _blendZones;
    private List<BasicEnclosure> _Enclosures;
    public List<BasicEnclosure> Enclosures => _enclosures;

    private void Start();
    public bool WithinEnclosure(Vector3 targetPosition, out float blend);
}