using System.Collections.Generic;
using ScheduleOne.Core;
using ScheduleOne.Core.Weather;
using UnityEngine;

namespace ScheduleOne.Weather;
public class EnclosureVisualiser : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private bool _showEnclosures;
    private List<BasicEnclosure> enclosures;
    [Button]
    private void FindEnclosures();
    private void OnDrawGizmos();
}