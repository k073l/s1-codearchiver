using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio;
public class StartLoopStopAudio : MonoBehaviour
{
    [FormerlySerializedAs("FadeLoopIn")]
    [SerializeField]
    private bool _fadeLoopIn;
    [FormerlySerializedAs("FadeLoopOut")]
    [SerializeField]
    private bool _fadeLoopOut;
    [FormerlySerializedAs("StartSound")]
    [SerializeField]
    private AudioSourceController _startSound;
    [FormerlySerializedAs("LoopSound")]
    [SerializeField]
    private AudioSourceController _loopSound;
    [FormerlySerializedAs("StopSound")]
    [SerializeField]
    private AudioSourceController _stopSound;
    private Coroutine _audioRoutine;
    private bool _isRunning;
    private void Awake();
    public void StartAudio();
    public void StopAudio();
    private IEnumerator StartAudioRoutine();
    private IEnumerator StopAudioRoutine();
    private void TryStartAudio();
    private void TryStopAudio();
}