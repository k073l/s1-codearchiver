using ScheduleOne.NPCs;
using ScheduleOne.Police;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Tools;
[RequireComponent(typeof(Rigidbody))]
public class CombatNPCDetector : MonoBehaviour
{
    public bool DetectOnlyInCombat;
    public UnityEvent onDetected;
    public float ContactTimeForDetection;
    private bool inContact;
    private NPC npcInContact;
    private float contactTime;
    private void Awake();
    private void FixedUpdate();
    private void OnTriggerEnter(Collider other);
    private void OnTriggerExit(Collider other);
}