using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.ScriptableObjects;
using ScheduleOne.UI.Phone;
using UnityEngine;

namespace ScheduleOne.Calling;
public class CallManager : Singleton<CallManager>
{
    public PhoneCallData QueuedCallData { get; private set; }

    protected override void Start();
    protected override void OnDestroy();
    public void QueueCall(PhoneCallData data);
    public void ClearQueuedCall();
    private void CallCompleted(PhoneCallData call);
}