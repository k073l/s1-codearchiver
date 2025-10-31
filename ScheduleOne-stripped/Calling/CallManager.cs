using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.ScriptableObjects;
using ScheduleOne.UI.Phone;
using UnityEngine;

namespace ScheduleOne.Calling;
public class CallManager : Singleton<CallManager>
{
    private PhoneCallData QueuedCallData { get; set; }

    public event Action<PhoneCallData> OnCallQueued;
    protected override void Start();
    protected override void OnDestroy();
    public void QueueCall(PhoneCallData data);
    public void ClearQueuedCall();
    private void CallCompleted(PhoneCallData call);
}