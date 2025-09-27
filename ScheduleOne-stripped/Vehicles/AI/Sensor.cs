using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Vehicles.AI;
public class Sensor : MonoBehaviour
{
    public bool Enabled;
    public Collider obstruction;
    public float obstructionDistance;
    public const float checkRate;
    [Header("Settings")]
    [SerializeField]
    protected float minDetectionRange;
    [SerializeField]
    protected float maxDetectionRange;
    public float checkRadius;
    public LayerMask checkMask;
    private LandVehicle vehicle;
    [HideInInspector]
    public float calculatedDetectionRange;
    private RaycastHit hit;
    private List<RaycastHit> hits;
    protected virtual void Start();
    public void Check();
}