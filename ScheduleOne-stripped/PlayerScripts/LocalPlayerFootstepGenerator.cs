using ScheduleOne.Tools;
using UnityEngine;

namespace ScheduleOne.PlayerScripts;
[RequireComponent(typeof(PlayerMovement))]
public class LocalPlayerFootstepGenerator : GenericFootstepDetector
{
    private const float DistancePerStep;
    private PlayerMovement _movement;
    private float _currentDistance;
    private Vector3 _lastFramePosition;
    private void Awake();
    protected void LateUpdate();
}