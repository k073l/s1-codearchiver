using ScheduleOne.Interaction;
using UnityEngine;

namespace ScheduleOne.Growing;
public class GrowContainerInteraction : MonoBehaviour
{
    [SerializeField]
    private InteractableObject _interactableObject;
    private bool _interactableActivatedThisFrame;
    private Vector3 displayLocationPointDefaultLocalPosition;
    protected virtual void Awake();
    private void LateUpdate();
    public void ConfigureInteraction(string labelText, InteractableObject.EInteractableState interactionState, bool setLabelPosition = false, Vector3 labelPosition = default(Vector3));
    protected virtual bool TryGetFallbackInteractionMessage(out string message, out InteractableObject.EInteractableState state);
}