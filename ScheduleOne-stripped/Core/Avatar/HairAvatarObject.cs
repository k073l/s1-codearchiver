using ScheduleOne.Core.Avatar.Properties;
using UnityEngine;

namespace ScheduleOne.Core.Avatar;
public class HairAvatarObject : AvatarObject
{
    [SerializeField]
    private GameObject[] _disabledWhenHairBlocked;
    [SerializeField]
    private GameObject[] _enabledWhenHairBlocked;
    public void SetHairBlocked(bool blocked);
    public void SetHairColor(Color color);
}