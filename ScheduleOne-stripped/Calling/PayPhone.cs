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
    public BlinkingLight Light;
    public AudioSourceController RingSound;
    public AudioSourceController AnswerSound;
    public InteractableObject IntObj;
    public Transform CameraPosition;
    private float timeSinceLastRing;
    private const float ringRangeSquared;
    public PhoneCallData QueuedCall => Singleton<CallManager>.Instance.QueuedCallData;
    public PhoneCallData ActiveCall => Singleton<CallInterface>.Instance.ActiveCallData;

    public void FixedUpdate();
    public void Hovered();
    public void Interacted();
    private bool CanInteract();
}