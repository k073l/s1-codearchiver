using ScheduleOne.Misc;
using ScheduleOne.PlayerTasks;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.ObjectScripts;
public class LabOvenButton : MonoBehaviour
{
    private const float ANIMATION_TIME;
    public Transform Button;
    public Transform PressedTransform;
    public Transform DepressedTransform;
    public ToggleableLight Light;
    public Clickable Clickable;
    private float animationTimer;
    private Vector3 animationStartPos;
    private Vector3 animationEndPos;
    public bool Pressed { get; private set; }

    private void Start();
    public void SetInteractable(bool interactable);
    public void Press(RaycastHit hit);
    public void SetPressed(bool pressed);
    private void Update();
}