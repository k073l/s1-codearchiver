using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.ObjectScripts;
using ScheduleOne.Tools;
using UnityEngine;

namespace ScheduleOne.Growing;
public class PotInteraction : GrowContainerInteraction
{
    [SerializeField]
    private Pot _pot;
    protected override void Awake();
    protected override bool TryGetFallbackInteractionMessage(out string message, out InteractableObject.EInteractableState state);
}