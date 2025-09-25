using ScheduleOne.Interaction;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.TV;
public class TVInteractable : MonoBehaviour
{
    public InteractableObject IntObj;
    public TVInterface Interface;
    private void Start();
    private void Hovered();
    private void Interacted();
}