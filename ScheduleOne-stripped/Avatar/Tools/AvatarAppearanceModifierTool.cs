using ScheduleOne.Core.Avatar;
using UnityEngine;

namespace ScheduleOne.Avatar.Tools;
[RequireComponent(typeof(AvatarAppearance))]
public class AvatarAppearanceModifierTool : MonoBehaviour
{
    public AvatarObject _avatarObject;
    private AvatarObject _lastAppliedObject;
    private AvatarAppearance _avatarAppearance => ((Component)this).GetComponent<AvatarAppearance>();
}