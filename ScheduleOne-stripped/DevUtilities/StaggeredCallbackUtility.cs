using System;
using System.Collections;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public class StaggeredCallbackUtility : Singleton<StaggeredCallbackUtility>
{
    public void InvokeStaggered(int totalCalls, float totalTime, Action<int> callback, Action onComplete = null);
    public void InvokeStaggered(int totalCalls, int callsPerSecond, Action<int> callback, Action onComplete = null);
}