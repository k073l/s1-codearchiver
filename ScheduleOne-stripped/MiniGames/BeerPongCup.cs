using System;
using System.Collections;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.MiniGames;
public class BeerPongCup : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private GameObject _splashFx;
    [SerializeField]
    private AudioSourceController _splashSound;
    [SerializeField]
    private GameObject _liquidObject;
    private Vector3 _initialPosition;
    public bool IsCurrentlyInStack { get; private set; }

    public event Action<TableTennisBall> OnBallEnteredCup;
    private void Awake();
    public void MoveToStack(Vector3 stackPosition);
    public void ResetPosition();
    public void PlaySplash();
    private IEnumerator Delay(float seconds, Action callback);
    private void OnTriggerEnter(Collider other);
}