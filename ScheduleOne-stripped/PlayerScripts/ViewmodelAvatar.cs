using ScheduleOne.AvatarFramework;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace ScheduleOne.PlayerScripts;
public class ViewmodelAvatar : Singleton<ViewmodelAvatar>
{
    [SerializeField]
    private float ArmShift;
    public Avatar ParentAvatar;
    public Animator Animator;
    public Avatar Avatar;
    public Transform RightHandContainer;
    private Vector3 _leftShoulderDefaultLocalPos;
    private Vector3 _rightShoulderDefaultLocalPos;
    public bool IsVisible { get; private set; }

    protected override void Awake();
    public void SetVisibility(bool isVisible);
    private void LateUpdate();
    private void SetBoneTransforms();
    public void SetAppearance(AvatarSettings settings);
    public void SetAnimatorController(RuntimeAnimatorController controller);
    public void SetOffset(Vector3 offset);
    public void SetRotationOffset(Vector3 eulerAngles);
}