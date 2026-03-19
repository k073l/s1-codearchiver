using System.Collections;
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
    private NPC npcInContact;
    private float contactTime;
    private Coroutine detectionRoutine;
    private void Awake();
    private IEnumerator UpdateWhileDetected();
    private void OnTriggerEnter(Collider other);
    private void OnTriggerExit(Collider other);
}