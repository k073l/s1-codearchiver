using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Management;
using ScheduleOne.NPCs;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Management;
public class NPCFieldUI : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI FieldLabel;
    public Image IconImg;
    public TextMeshProUGUI SelectionLabel;
    public GameObject NoneSelected;
    public GameObject MultipleSelected;
    public RectTransform ClearButton;
    public List<NPCField> Fields { get; protected set; } = new List<NPCField>();

    public void Bind(List<NPCField> field);
    private void Refresh(NPC newVal);
    private bool AreFieldsUniform();
    public void Clicked();
    public void NPCSelected(NPC npc);
    public void ClearClicked();
}