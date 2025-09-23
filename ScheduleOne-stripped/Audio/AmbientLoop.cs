using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;

namespace ScheduleOne.Audio;
[RequireComponent(typeof(AudioSourceController))]
public class AmbientLoop : MonoBehaviour
{
    public const float MUSIC_FADE_MULTIPLIER;
    public AnimationCurve VolumeCurve;
    public bool FadeDuringMusic;
    private AudioSourceController audioSourceController;
    private float musicScale;
    private void Start();
    private void Update();
}