using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour;
public class PhoneBehaviour : MoveToAndActBehaviour
{
    private const float MinTimeBetweenTalk;
    private const float MaxTimeBetweenTalk;
    private const float VoiceVolumeMultiplier;
    private Coroutine _actingCo;
    private EVOLineType[] _voLines;
    private string[] _emotions;
    private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EPhoneBehaviourAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EPhoneBehaviourAssembly_002DCSharp_002Edll_Excuted;
    protected override void OnStartAct();
    protected override void OnEndAct();
    private IEnumerator DoConversingRoutine();
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}