using System;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers;
public class Hydraulics : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Transform _target;
    [Header("Bounce")]
    public float bounceHeight;
    public float bounceFrequency;
    public float bounceDampening;
    [Header("Seesaw")]
    public float pitchAmount;
    public float rollAmount;
    public float rollPitchDampening;
    [Header("Music")]
    public float musicIntensity;
    public float BPM;
    public int beatsPerBounce;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private float currentBounce;
    private float targetBounce;
    private float targetPitch;
    private float targetRoll;
    private float currentPitch;
    private float currentRoll;
    private float musicFrequency;
    private float secondsPerBounce;
    private float secondsPerBeat;
    public void OnValidate();
    private void Start();
    private void Setup();
    private void SetupMusicFrequency();
    private void Update();
    private void HanldeHydraulicMotion();
}