using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks;
public class Draggable : Clickable
{
    public enum EDragProjectionMode
    {
        CameraForward,
        FlatCameraForward,
        CustomPlane
    }

    public enum ERotationAxis
    {
        FlatCameraForward,
        LocalX,
        LocalY,
        LocalZ
    }

    [Header("Drag Force")]
    public float DragForceMultiplier;
    public Transform DragForceOrigin;
    [Header("Rotation")]
    public bool RotationEnabled;
    public float TorqueMultiplier;
    public ERotationAxis RotationAxis;
    [Header("Settings")]
    public EDragProjectionMode DragProjectionMode;
    public Transform CustomDragPlane;
    public bool DisableGravityWhenDragged;
    public float NormalRBDrag;
    public float HeldRBDrag;
    public bool CanBeMultiDragged;
    [Header("Additional force")]
    public float idleUpForce;
    [HideInInspector]
    public bool LocationRestrictionEnabled;
    [HideInInspector]
    public Vector3 Origin;
    [HideInInspector]
    public float MaxDistanceFromOrigin;
    public UnityEvent<Collider> onTriggerExit;
    protected DraggableConstraint constraint;
    public Rigidbody Rb { get; protected set; }
    public override CursorManager.ECursorType HoveredCursor { get; protected set; } = CursorManager.ECursorType.OpenHand;

    protected virtual void Awake();
    protected virtual void FixedUpdate();
    protected virtual void Update();
    public virtual void PostFixedUpdate();
    protected virtual void LateUpdate();
    protected virtual void OnTriggerExit(Collider other);
    public override void StartClick(RaycastHit hit);
    public override void EndClick();
}