using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.ObjectScripts;
public class StirringRod : MonoBehaviour
{
    public const float MAX_STIR_RATE;
    public const float MAX_PIVOT_ANGLE;
    public float LerpSpeed;
    [Header("References")]
    public Clickable Clickable;
    public Transform PlaneNormal;
    public Transform Container;
    public Transform RodPivot;
    public AudioSourceController StirSound;
    private Vector3 clickOffset;
    private bool isMoving;
    public bool Interactable { get; private set; }
    public float CurrentStirringSpeed { get; private set; }

    private void Start();
    private void Update();
    private void LateUpdate();
    public void SetInteractable(bool e);
    public void ClickStart(RaycastHit hit);
    private Vector3 GetPlaneHit();
    public void ClickEnd();
    public void Destroy();
}