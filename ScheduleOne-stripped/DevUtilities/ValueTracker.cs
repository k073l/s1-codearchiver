using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.GameTime;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public class ValueTracker
{
    public class Value
    {
        public float val;
        public float time;
        public Value(float val, float time);
    }

    private float historyDuration;
    private List<Value> valueHistory;
    public ValueTracker(float HistoryDuration);
    public void Destroy();
    public void Update();
    public void SubmitValue(float value);
    public float RecordedHistoryLength();
    public float GetLowestValue();
    public float GetAverageValue();
}