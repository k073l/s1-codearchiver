using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.ObjectScripts;
public class LabStand : MonoBehaviour
{
    [Header("Settings")]
    public float MoveSpeed;
    public bool FunnelEnabled;
    public float FunnelThreshold;
    [Header("References")]
    public Animation Anim;
    public Transform GripTransform;
    public Transform SpinnyThingy;
    public Transform RaisedTransform;
    public Transform LoweredTransform;
    public Transform PlaneNormal;
    public Clickable HandleClickable;
    public Transform Funnel;
    public GameObject Highlight;
    public AudioSourceController LowerSound;
    public AudioSourceController RaiseSound;
    private Vector3 clickOffset;
    private bool isMoving;
    public bool Interactable { get; private set; }
    public float CurrentPosition { get; private set; } = 1f;

    private void Start();
    private void LateUpdate();
    private void Move();
    private void UpdateSound(float difference);
    public void SetPosition(float position);
    public void SetInteractable(bool e);
    public void ClickStart(RaycastHit hit);
    private Vector3 GetPlaneHit();
    public void ClickEnd();
}