using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.UI.Input;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Interaction;
public class InteractableObject : MonoBehaviour
{
    public enum EInteractionType
    {
        Key_Press,
        LeftMouse_Click
    }

    public enum EInteractableState
    {
        Default,
        Invalid,
        Disabled,
        Label
    }

    [Header("Settings")]
    [SerializeField]
    protected string message;
    [SerializeField]
    protected EInteractionType interactionType;
    [SerializeField]
    protected EInteractableState interactionState;
    public float MaxInteractionRange;
    public bool RequiresUniqueClick;
    public int Priority;
    [SerializeField]
    protected Collider displayLocationCollider;
    public Transform displayLocationPoint;
    [Header("Angle Limits")]
    public bool LimitInteractionAngle;
    public float AngleLimit;
    [Header("Events")]
    public UnityEvent onHovered;
    public UnityEvent onInteractStart;
    public UnityEvent onInteractEnd;
    private bool _isMessageActive;
    private InputPromptsBindingData _currentBindingData;
    private InputPromptsDescriptorData _descriptorData;
    public EInteractionType _interactionType => interactionType;
    public EInteractableState _interactionState => interactionState;

    public void Start();
    public void SetInteractionType(EInteractionType type);
    public void SetInteractableState(EInteractableState state);
    public void SetMessage(string _message);
    public virtual void Hovered();
    public virtual void Exited();
    public virtual void StartInteract();
    public virtual void EndInteract();
    protected virtual void ShowMessage();
    public bool CheckAngleLimit(Vector3 interactionSource);
    private void SetInputData();
    private void OnInputChange(GameInput.InputDeviceType deviceType);
    private void OnDestroy();
}