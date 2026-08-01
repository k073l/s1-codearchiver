using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Gamepad;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.UI.Input;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.ObjectScripts;
public class BrickPressHandle : MonoBehaviour
{
    private float lastClickPosition;
    [Header("Settings")]
    public float MoveSpeed;
    public bool Locked;
    [Header("References")]
    public Transform PlaneNormal;
    public Transform RaisedTransform;
    public Transform LoweredTransform;
    public Clickable HandleClickable;
    public AudioSourceController ClickSound;
    [Header("Prompt Data")]
    [SerializeField]
    private InputPromptsData _handlePromptData;
    [SerializeField]
    private Transform _handlePromptAnchor;
    private Vector3 clickOffset;
    private bool isMoving;
    private float _currentVerticalPos;
    public bool Interactable { get; private set; }
    public float CurrentPosition { get; private set; }
    public float TargetPosition { get; private set; }

    private void Start();
    private void LateUpdate();
    private void Move();
    private void UpdateSound(float difference);
    public void SetPosition(float position);
    public void SetInteractable(bool e);
    public void ClickStart(RaycastHit hit);
    public void ClickEnd();
    private Vector3 GetPlaneHit();
    private bool HasValidGamepadRotationInput();
}