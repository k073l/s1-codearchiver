using System;
using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dialogue;
using ScheduleOne.Doors;
using ScheduleOne.Interaction;
using ScheduleOne.Levelling;
using ScheduleOne.NPCs.CharacterClasses;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Map;
public class DarkMarketMainDoor : MonoBehaviour
{
    public AudioSource KnockSound;
    public InteractableObject InteractableObject;
    public Peephole Peephole;
    public Igor Igor;
    public Conversation FailDialogue;
    public Conversation SuccessDialogue;
    public Conversation SuccessDialogueNotOpen;
    private Coroutine knockRoutine;
    public bool KnockingEnabled { get; private set; } = true;

    public void SetKnockingEnabled(bool enabled);
    public void Hovered();
    public void Interacted();
    private void Knocked();
}