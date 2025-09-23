using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ScheduleOne.DevUtilities;
using ScheduleOne.Map;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.Persistence;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Police;
using ScheduleOne.Vehicles;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Law;
public class LawManager : Singleton<LawManager>
{
    [Serializable]
    [CompilerGenerated]
    private sealed class _003C_003Ec
    {
        public static readonly _003C_003Ec _003C_003E9;
        public static UnityAction _003C_003E9__2_0;
        internal void _003CStart_003Eb__2_0();
    }

    public const int DISPATCH_OFFICER_COUNT;
    public static float DISPATCH_VEHICLE_USE_THRESHOLD;
    protected override void Start();
    public void PoliceCalled(Player target, Crime crime);
    public PatrolGroup StartFootpatrol(FootPatrolRoute route, int requestedMembers);
    public PoliceOfficer StartVehiclePatrol(VehiclePatrolRoute route);
}