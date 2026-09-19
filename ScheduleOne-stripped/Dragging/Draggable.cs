using System;
using FishNet.Connection;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Dragging;
[RequireComponent(typeof(InteractableObject))]
public class Draggable : MonoBehaviour, IGUIDRegisterable
{
    public const float DraggableInteractionRange;
    public const float PositionDeltaToDropDraggable;
    [Header("Settings")]
    [Range(0.5f, 2f)]
    public float HoldDistanceMultiplier;
    [Range(0f, 5f)]
    public float DragForceMultiplier;
    [Range(0.1f, 2f)]
    public float ThrowForceMultiplier;
    [Header("References")]
    protected Rigidbody _rigidbody;
    protected InteractableObject _interactable;
    [Header("Optional References")]
    [SerializeField]
    private Transform DragOrigin;
    private Player _currentDragger;
    private float _timeOnLastDragStop;
    private CollisionDetectionMode _defaultCollisionDetectionMode;
    public bool IsBeingDragged => (Object)(object)CurrentDragger != (Object)null;
    public Player CurrentDragger { get; protected set; }
    public Guid GUID { get; protected set; }
    public Vector3 InitialPosition { get; private set; }
    public Vector3 Velocity { get; }
    public float Mass { get; }

    protected virtual void Awake();
    protected virtual void Start();
    private void OnDisable();
    public void SetGUID(Guid guid);
    protected void OnDestroy();
    public virtual bool ShouldReplicateInitialTransformForClient(NetworkConnection conn);
    public void UpdateDraggable();
    public void ApplyDragForces(Vector3 targetPosition);
    protected virtual void Hovered();
    protected virtual void Interacted();
    protected virtual bool CanStartDrag();
    public void StartDragging(Player dragger);
    public void StopDragging();
    public void SetTransformData(Vector3 position, Quaternion rotation);
    public void SetVelocity(Vector3 velocity);
    public void SetRigidbody(Rigidbody rb);
}