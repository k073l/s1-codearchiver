using ScheduleOne.Audio;
using ScheduleOne.Combat;
using UnityEngine;

namespace ScheduleOne.MiniGames;
public class BoxingBag : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private NetworkedPhysicsDamageable _damageable;
    [SerializeField]
    private Transform _boxingBagObj;
    [Header("Settings")]
    [SerializeField]
    private float _impactThreshold;
    [SerializeField]
    [Range(-1f, 1f)]
    private float _angleThreshold;
    [SerializeField]
    private float _checkTime;
    [Header("Audio")]
    [SerializeField]
    private AudioSourceController _audioController;
    private float _timer;
    private bool _isChecking;
    private void Start();
    private void Update();
    private void OnImpact(Impact impact);
}