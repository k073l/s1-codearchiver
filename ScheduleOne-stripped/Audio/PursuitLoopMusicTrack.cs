using System.Collections;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Audio;
public class PursuitLoopMusicTrack : PursuitMusicTrack
{
    public AudioSourceController LoopSound;
    protected override void Awake();
    public override void Stop();
    protected override void Update();
    public override void Play();
}