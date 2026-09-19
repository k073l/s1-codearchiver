using ScheduleOne.Core.Avatar;
using UnityEngine;

namespace ScheduleOne.Law;
public class PoliceBelt : AvatarObject
{
    [Header("References")]
    [SerializeField]
    private GameObject BatonObject;
    [SerializeField]
    private GameObject TaserObject;
    [SerializeField]
    private GameObject GunObject;
    public override void Initialize(IAvatar avatar);
    public void SetBatonVisible(bool vis);
    public void SetTaserVisible(bool vis);
    public void SetGunVisible(bool vis);
}