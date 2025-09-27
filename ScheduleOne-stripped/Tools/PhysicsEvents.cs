using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Tools;
public class PhysicsEvents : MonoBehaviour
{
    public bool DEBUG;
    public UnityEvent<Collider> OnTriggerEnterEvent;
    public UnityEvent<Collider> OnTriggerExitEvent;
    public UnityEvent<Collision> OnCollisionEnterEvent;
    public UnityEvent<Collision> OnCollisionExitEvent;
    public void OnTriggerEnter(Collider other);
    public void OnTriggerExit(Collider other);
    public void OnCollisionEnter(Collision collision);
    public void OnCollisionExit(Collision collision);
    private static string GetHierarchyString(Transform transform);
}