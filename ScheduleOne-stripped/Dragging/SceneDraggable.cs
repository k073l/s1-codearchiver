using System;
using FishNet.Connection;
using ScheduleOne.Core;
using ScheduleOne.Interaction;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Dragging;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InteractableObject))]
public class SceneDraggable : Draggable
{
    public enum EInitialReplicationMode
    {
        Off,
        OnlyIfMoved,
        Full
    }

    private const float MovedThreshold;
    [Header("Settings")]
    [SerializeField]
    [FormerlySerializedAs("InitialReplicationMode")]
    private EInitialReplicationMode _initialReplicationMode;
    [SerializeField]
    private string BakedGUID;
    public EInitialReplicationMode InitialReplicationMode => _initialReplicationMode;

    protected override void Awake();
    public override bool ShouldReplicateInitialTransformForClient(NetworkConnection conn);
    [Button]
    private void RegenerateGUID();
}