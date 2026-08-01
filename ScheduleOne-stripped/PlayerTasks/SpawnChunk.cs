using System.Collections.Generic;
using ScheduleOne.Audio;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks;
[RequireComponent(typeof(Clickable))]
[RequireComponent(typeof(Rigidbody))]
public class SpawnChunk : Clickable
{
    private MeshRenderer _meshRenderer;
    private Rigidbody _rb;
    private Collider _collider;
    private bool _isBroken;
    private List<SpawnChunk> _childChunks;
    public UnityEvent OnBreak;
    private bool hasChildChunks => _childChunks.Count > 0;
    public override bool RegisterDefaultLureWhenEmpty => true;

    private void Awake();
    public void EnableChunk(Vector3 force, Vector3 torque);
    public void DisableChunk(bool recursive);
    public void Break();
    public bool GetIsBroken(bool recursive = true);
    public override void StartClick(RaycastHit hit);
    private void Push();
    public void SetChunkOrder(int i);
}