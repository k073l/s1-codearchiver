using EasyButtons;
using FishNet.Object;
using ScheduleOne.DevUtilities;
using ScheduleOne.NPCs;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Equipping;
public class AvatarEquippable : MonoBehaviour
{
    public enum ETriggerType
    {
        Trigger,
        Bool
    }

    public enum EHand
    {
        Left,
        Right
    }

    [Header("Settings")]
    public Transform AlignmentPoint;
    [Range(0f, 1f)]
    public float Suspiciousness;
    public EHand Hand;
    public ETriggerType TriggerType;
    public string AnimationTrigger;
    public string AssetPath;
    protected Avatar avatar;
    [Button]
    public void RecalculateAssetPath();
    protected virtual void Awake();
    public virtual void Equip(Avatar _avatar);
    public virtual void InitializeAnimation();
    public virtual void Unequip();
    private void PositionAnimationModel();
    protected void SetTrigger(string anim);
    protected void SetBool(string anim, bool val);
    protected void ResetTrigger(string anim);
    public virtual void ReceiveMessage(string message, object parameter);
}