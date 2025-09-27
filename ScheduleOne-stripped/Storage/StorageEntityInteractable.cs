using ScheduleOne.Interaction;
using UnityEngine;

namespace ScheduleOne.Storage;
public class StorageEntityInteractable : InteractableObject
{
    private StorageEntity StorageEntity;
    private void Awake();
    public override void Hovered();
    public override void StartInteract();
}