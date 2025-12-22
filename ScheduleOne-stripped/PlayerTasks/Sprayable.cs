using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerTasks;
public class Sprayable : Draggable
{
    [Header("Sprayable Components")]
    [SerializeField]
    private Transform _sprayOrigin;
    [Header("Gizmos")]
    [SerializeField]
    private bool _drawGizmos;
    public Action _onSuccessfulSpray;
    public UnityEvent onSpray;
    private float _sprayRadius;
    private float _sprayDistance;
    private Vector3 _currentTargetPosition;
    public void Initialise(float sprayRadius, float sprayDistance);
    protected override void Update();
    private void Spray();
    public void SetCurrentTarget(Vector3 position);
    private bool DoesHitTarget(Vector3 rayOrigin, Vector3 rayDirection, Vector3 sphereCenter, float sphereRadius, float maxDistance);
    public void SubscribeToSuccessfulSpray(Action callback);
    public void UnsubscribeFromSuccessfulSpray(Action callback);
    private void OnDrawGizmos();
}