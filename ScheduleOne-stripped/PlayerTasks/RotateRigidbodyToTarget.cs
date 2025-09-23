using UnityEngine;

namespace ScheduleOne.PlayerTasks;
public class RotateRigidbodyToTarget : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Vector3 TargetRotation;
    public float RotationForce;
    public Transform Bitch;
    public void FixedUpdate();
}