using System.Linq;
using UnityEngine;

namespace ScheduleOne.Cartel;
public class CartelAmbushLocation : MonoBehaviour
{
    public const int REQUIRED_AMBUSH_POINTS;
    [Header("Settings")]
    [Range(2f, 20f)]
    public float DetectionRadius;
    public Transform[] AmbushPoints;
    private void Awake();
    private void OnDrawGizmos();
}