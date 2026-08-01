using System;
using ScheduleOne.VoiceOver;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class Voice
{
    public VODatabase VoiceDatabase;
    [Range(0.1f, 4f)]
    public float VoicePitch;
    public Voice GetCopy();
}