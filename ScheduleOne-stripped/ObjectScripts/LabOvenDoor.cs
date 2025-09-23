using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.ObjectScripts;
public class LabOvenDoor : MonoBehaviour
{
    public const float HIT_OFFSET_MAX;
    public const float HIT_OFFSET_MIN;
    public const float DOOR_ANGLE_CLOSED;
    public const float DOOR_ANGLE_OPEN;
    [Header("References")]
    public Clickable HandleClickable;
    public Transform Door;
    public Transform PlaneNormal;
    public AnimationCurve HitMapCurve;
    [Header("Sounds")]
    public AudioSourceController OpenSound;
    public AudioSourceController CloseSound;
    public AudioSourceController ShutSound;
    [Header("Settings")]
    public float DoorMoveSpeed;
    private Vector3 clickOffset;
    private bool isMoving;
    public bool Interactable { get; private set; }
    public float TargetPosition { get; private set; }
    public float ActualPosition { get; private set; }

    private void Start();
    private void LateUpdate();
    private void Move();
    public void SetInteractable(bool interactable);
    public void SetPosition(float newPosition);
    public void ClickStart(RaycastHit hit);
    private Vector3 GetPlaneHit();
    public void ClickEnd();
}