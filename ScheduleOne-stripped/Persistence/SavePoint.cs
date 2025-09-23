using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Persistence;
public class SavePoint : MonoBehaviour
{
    public const float SAVE_COOLDOWN;
    public InteractableObject IntObj;
    public UnityEvent onSaveStart;
    public UnityEvent onSaveComplete;
    public void Awake();
    public void Hovered();
    private bool CanSave(out string reason);
    public void Interacted();
    private void Save();
    public void OnSaveStart();
    public void OnSaveComplete();
}