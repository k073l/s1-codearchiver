using System;
using System.Collections;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.Lighting;
using ScheduleOne.PlayerScripts;
using ScheduleOne.ScriptableObjects;
using ScheduleOne.UI.Phone;
using UnityEngine;

namespace ScheduleOne.Calling;
public class PayPhone : MonoBehaviour
{
    public const float RING_INTERVAL;
    public const float RING_RANGE;
    private const float ringRangeSquared;
    public PhoneCallData QueuedCall;
    public PhoneCallData ActiveCall;
    public BlinkingLight Light;
    public AudioSourceController RingSound;
    public AudioSourceController AnswerSound;
    public InteractableObject IntObj;
    public Transform CameraPosition;
    private float lastRingTime;
    private Coroutine periodicRingHandle;
    private void Start();
    private void OnDestroy();
    private void OnCallStarted(PhoneCallData data);
    private void OnCallCompleted(PhoneCallData data);
    private void OnCallQueued(PhoneCallData data);
    private void UpdateCallState();
    private IEnumerator PeriodicRing();
    public void Hovered();
    public void Interacted();
    private bool CanInteract();
}