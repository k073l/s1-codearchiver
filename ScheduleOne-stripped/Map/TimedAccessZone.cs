using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;

namespace ScheduleOne.Map;
public class TimedAccessZone : AccessZone
{
    [Header("Timing Settings")]
    public int OpenTime;
    public int CloseTime;
    protected virtual void Start();
    protected virtual void OnUncappedMinPass();
    protected virtual bool GetIsOpen();
}