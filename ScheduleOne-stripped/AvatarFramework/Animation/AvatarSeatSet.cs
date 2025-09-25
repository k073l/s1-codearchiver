using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Animation;
public class AvatarSeatSet : MonoBehaviour
{
    public AvatarSeat[] Seats;
    public AvatarSeat GetFirstFreeSeat();
    public AvatarSeat GetRandomFreeSeat();
}