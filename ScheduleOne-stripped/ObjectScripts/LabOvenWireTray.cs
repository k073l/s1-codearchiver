using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.ObjectScripts;
public class LabOvenWireTray : MonoBehaviour
{
    public const float HIT_OFFSET_MAX;
    public const float HIT_OFFSET_MIN;
    [Header("References")]
    public Transform Tray;
    public Transform PlaneNormal;
    public Transform ClosedPosition;
    public Transform OpenPosition;
    public LabOvenDoor OvenDoor;
    [Header("Settings")]
    public float MoveSpeed;
    public AnimationCurve DoorClampCurve;
    private Vector3 clickOffset;
    private bool isMoving;
    public bool Interactable { get; private set; }
    public float TargetPosition { get; private set; }
    public float ActualPosition { get; private set; }

    private void Start();
    private void LateUpdate();
    private void Move();
    private void ClampAngle();
    public void SetInteractable(bool interactable);
    public void SetPosition(float position);
    public void ClickStart(RaycastHit hit);
    private Vector3 GetPlaneHit();
    public void ClickEnd();
}