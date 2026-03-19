using ScheduleOne.PlayerScripts;
using ScheduleOne.Vision;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio;
[RequireComponent(typeof(AudioSourceController))]
public class SpottedTremolo : MonoBehaviour
{
    private const float MinVolume;
    private const float MaxVolume;
    private const float MinPitch;
    private const float MaxPitch;
    private const float SmoothTime;
    [SerializeField]
    [FormerlySerializedAs("PlayerVisibility")]
    private EntityVisibility _visibilityComponent;
    private AudioSourceController _audio;
    private float _targetIntensity;
    private float _smoothedIntensity;
    private void Awake();
    private void Update();
}