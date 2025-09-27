using ScheduleOne.AvatarFramework;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace ScheduleOne.PlayerScripts;
public class ViewmodelAvatar : Singleton<ViewmodelAvatar>
{
    public Avatar ParentAvatar;
    public Animator Animator;
    public Avatar Avatar;
    public Transform RightHandContainer;
    public bool IsVisible { get; private set; }

    protected override void Awake();
    public void SetVisibility(bool isVisible);
    private void LateUpdate();
    private void ResetHipTransform();
    public void SetAppearance(AvatarSettings settings);
    public void SetAnimatorController(RuntimeAnimatorController controller);
    public void SetOffset(Vector3 offset);
    public void SetRotationOffset(Vector3 eulerAngles);
}