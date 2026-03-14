using System;
using ScheduleOne.GameTime;
using UnityEngine;

namespace ScheduleOne.Audio;
[Serializable]
public class AudioZoneTrack
{
    public AudioSourceController Source;
    [Range(0.01f, 2f)]
    public float Volume;
    public int StartTime;
    public int EndTime;
    public int FadeTime;
    private float timeVolMultiplier;
    private int fadeInStart;
    private int fadeInEnd;
    private int fadeOutStart;
    private int fadeOutEnd;
    private int fadeInStartMinSum;
    private int fadeInEndMinSum;
    private int fadeOutStartMinSum;
    private int fadeOutEndMinSum;
    public void Init();
    public void Update(float multiplier);
    public void UpdateTimeMultiplier(int time);
}