using ScheduleOne.Tools;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio;
public class HeartbeatSoundController : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("VolumeController")]
    private FloatSmoother _volumeController;
    [SerializeField]
    [FormerlySerializedAs("PitchController")]
    private FloatSmoother _pitchController;
    [SerializeField]
    [FormerlySerializedAs("sound")]
    private AudioSourceController _sound;
    public FloatSmoother VolumeController => _volumeController;
    public FloatSmoother PitchController => _pitchController;

    private void Awake();
    private void Update();
}