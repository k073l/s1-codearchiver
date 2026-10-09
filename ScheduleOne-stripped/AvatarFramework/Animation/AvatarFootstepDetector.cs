using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tools;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Animation;
[RequireComponent(typeof(Avatar))]
public class AvatarFootstepDetector : GenericFootstepDetector
{
    private const float StepThreshold;
    [SerializeField]
    private float _detectionRange;
    [SerializeField]
    private Transform _leftBone;
    [SerializeField]
    private Transform _rightBone;
    private Avatar _avatar;
    private bool _leftDown;
    private bool _rightDown;
    private float _detectionRangeSqr;
    private void Awake();
    protected virtual void LateUpdate();
}