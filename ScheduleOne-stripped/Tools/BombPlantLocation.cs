using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Tools;
public class BombPlantLocation : MonoBehaviour
{
    public const float COUNTDOWN_TIME;
    public const float BEEP_INTERVAL_MAX;
    public const float BEEP_INTERVAL_MIN;
    [Header("References")]
    public InteractableObject IntObj;
    public GameObject BombModel;
    public UnityEvent onPlantBomb;
    public UnityEvent onBeep;
    public UnityEvent onDetonate;
    public bool BombPlanted { get; private set; }

    private void Awake();
    private void Hovered();
    private void Interacted();
    public void PlantBomb();
    private bool CanPlantBomb();
}