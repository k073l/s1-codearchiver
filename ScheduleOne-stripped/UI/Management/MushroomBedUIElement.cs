using ScheduleOne.Management;
using ScheduleOne.ObjectScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Management;
public class MushroomBedUIElement : WorldspaceUIElement
{
    [Header("References")]
    public Image SpawnIcon;
    public GameObject NoSpawn;
    public Image Additive1Icon;
    public Image Additive2Icon;
    public Image Additive3Icon;
    public MushroomBed AssignedMustroomBed { get; protected set; }

    public void Initialize(MushroomBed bed);
    protected virtual void RefreshUI();
}