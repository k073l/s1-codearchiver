using UnityEngine;

namespace ScheduleOne.AvatarFramework;
public class Hair : Accessory
{
    [SerializeField]
    private GameObject[] hairToHide;
    public bool BlockedByHat { get; protected set; }
    public GameObject[] HairToHide => hairToHide;

    public void SetBlockedByHat(bool blocked);
    protected virtual void BlockHair();
    protected virtual void UnBlockHair();
}