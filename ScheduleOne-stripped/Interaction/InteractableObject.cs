using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
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
    public EInteractionType _interactionType => interactionType;
    public EInteractableState _interactionState => interactionState;

    public void SetInteractionType(EInteractionType type);
    public void SetInteractableState(EInteractableState state);
    public void SetMessage(string _message);
    public virtual void Hovered();
    public virtual void StartInteract();
    public virtual void EndInteract();
    protected virtual void ShowMessage();
    public bool CheckAngleLimit(Vector3 interactionSource);
}