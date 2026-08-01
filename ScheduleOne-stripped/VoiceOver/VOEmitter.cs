using ScheduleOne.Audio;
using ScheduleOne.NPCs.Framework;
using UnityEngine;

namespace ScheduleOne.VoiceOver;
[RequireComponent(typeof(AudioSourceController))]
public class VOEmitter : MonoBehaviour
{
    public const float PitchVariation;
    protected float _runtimePitchMultiplier;
    protected AudioSourceController _audioSourceController;
    protected VODatabase _defaultVODatabase;
    protected VODatabase _currentDatabase;
    protected VODatabase _defaultDatabase;
    protected float _defaultPitch;
    protected virtual void Awake();
    public void Initialize(NPCData data);
    public virtual void Play(EVOLineType lineType);
    public void SetRuntimePitchMultiplier(float pitchMultiplier);
    public void SetDatabase(VODatabase database, bool writeDefault = true);
    public void SetDefaultPitch(float pitch);
    public void ResetDatabase();
}