using System;
using System.Collections.Generic;
using ScheduleOne.Police;
using UnityEngine;

namespace ScheduleOne.Law;
public class SentryLocation : MonoBehaviour
{
    [Serializable]
    public class SentryRoute
    {
        public Transform[] RoutePoints;
        public int MinutesPerPoint;
    }

    [Header("References")]
    public List<SentryRoute> Routes;
    public List<PoliceOfficer> AssignedOfficers { get; private set; } = new List<PoliceOfficer>();
}