using UnityEngine;

namespace ScheduleOne.Audio;
[CreateAssetMenu(fileName = "AudioSettings", menuName = "ScriptableObjects/Audio/Audio Settings")]
public class AudioSettings : ScriptableObject
{
    [Header("Settings")]
    [SerializeField]
    private string _id;
    [SerializeField]
    private AudioSettingsWrapper _settings;
    public string Id => _id;
    public AudioSettingsWrapper Wrapper => _settings;
}