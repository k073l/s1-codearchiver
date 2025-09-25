using UnityEngine;

namespace ScheduleOne.Dialogue;
public class DialogueChoiceEnabler : MonoBehaviour
{
    public DialogueController DialogueController;
    public int ChoiceIndex;
    private DialogueController.DialogueChoice choice;
    private void Awake();
    private void OnValidate();
    public void EnableChoice();
    public void DisableChoice();
}