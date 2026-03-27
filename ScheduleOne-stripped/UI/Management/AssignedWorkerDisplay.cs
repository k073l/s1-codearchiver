using ScheduleOne.NPCs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Management;
public class AssignedWorkerDisplay : MonoBehaviour
{
    public Image Icon;
    public TextMeshProUGUI NameLabel;
    public void Set(NPC npc);
}