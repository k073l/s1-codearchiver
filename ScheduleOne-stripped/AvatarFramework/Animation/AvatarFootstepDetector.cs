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
    private Avatar _avatar;
    private bool _leftDown;
    private bool _rightDown;
    private float _detectionRangeSqr;
    private Transform _leftBone => _avatar.LeftFootBone;
    private Transform _rightBone => _avatar.RightFootBone;

    private void Awake();
    protected virtual void LateUpdate();
}