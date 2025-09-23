using ScheduleOne.Audio;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Vision;
using UnityEngine;

namespace ScheduleOne.UI;
public class SpottedTremolo : MonoBehaviour
{
    [Range(0f, 1f)]
    public float Intensity;
    public AudioSourceController Loop;
    public EntityVisibility PlayerVisibility;
    [Header("Settings")]
    public float MinVolume;
    public float MaxVolume;
    public float MinPitch;
    public float MaxPitch;
    public float SmoothTime;
    [Range(0f, 1f)]
    [SerializeField]
    private float smoothedIntensity;
    public void Update();
}