using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Map;
using ScheduleOne.Police;
using UnityEngine;

namespace ScheduleOne.Law;
[Serializable]
public class SentryInstance
{
    public SentryLocation[] _potentialLocations;
    public int Members;
    [Header("Timing")]
    public int StartTime;
    public int EndTime;
    [Range(1f, 10f)]
    public int IntensityRequirement;
    public bool OnlyIfCurfewEnabled;
    private List<PoliceOfficer> _activeOfficers;
    private SentryLocation _activeLocation;
    public void Evaluate();
    public void StartEntry();
    private void MinPass();
    public void EndSentry();
    private SentryLocation GetRandomUnoccupiedLocation();
}