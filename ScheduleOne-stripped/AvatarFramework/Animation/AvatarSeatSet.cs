using System.Collections.Generic;
using System.Linq;
using GameKit.Utilities;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Animation;
public class AvatarSeatSet : MonoBehaviour
{
    public AvatarSeat[] Seats;
    public AvatarSeat GetFirstFreeSeat();
    public AvatarSeat GetRandomFreeSeat();
    public List<AvatarSeat> GetRandomFreeSeats(int amount);
    public bool HasFreeSeats();
    public int GetFreeSeatCount();
}