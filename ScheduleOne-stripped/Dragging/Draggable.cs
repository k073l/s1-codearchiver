using System;
using EasyButtons;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Dragging;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InteractableObject))]
public class Draggable : MonoBehaviour, IGUIDRegisterable
{
    public enum EInitialReplicationMode
    {
        Off,
        OnlyIfMoved,
        Full
    }

    public const float INITIAL_REPLICATION_DISTANCE;
    public const float MAX_DRAG_START_RANGE;
    public const float MAX_TARGET_OFFSET;
    private bool isBeingDragged;
    private Player currentDragger;
    [SerializeField]
    protected string BakedGUID;
    [Header("References")]
    public Rigidbody Rigidbody;
    public InteractableObject IntObj;
    public Transform DragOrigin;
    [Header("Settings")]
    public bool CreateCoM;
    [Range(0.5f, 2f)]
    public float HoldDistanceMultiplier;
    [Range(0f, 5f)]
    public float DragForceMultiplier;
    public EInitialReplicationMode InitialReplicationMode;
    private float timeSinceLastDrag;
    public UnityEvent onDragStart;
    public UnityEvent onDragEnd;
    public UnityEvent onHovered;
    public UnityEvent onInteracted;
    public bool IsBeingDragged => isBeingDragged;
    public Player CurrentDragger { get; protected set; }
    public Guid GUID { get; protected set; }
    public Vector3 initialPosition { get; private set; }

    [Button]
    public void RegenerateGUID();
    protected virtual void Awake();
    protected virtual void Start();
    public void SetGUID(Guid guid);
    protected void OnValidate();
    protected void OnDestroy();
    public void UpdateDraggable(float fixedDeltaTime);
    public void ApplyDragForces(Vector3 targetPosition);
    protected virtual void Hovered();
    protected virtual void Interacted();
    private bool CanInteract();
    public void StartDragging(Player dragger);
    public void StopDragging();
}