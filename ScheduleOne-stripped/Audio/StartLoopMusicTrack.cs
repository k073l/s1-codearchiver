using System.Collections;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Audio;
public class StartLoopMusicTrack : MusicTrack
{
    public AudioSourceController LoopSound;
    protected override void Awake();
    private void Start();
    protected override void Update();
    public override void Play();
}