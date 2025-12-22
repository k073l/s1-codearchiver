using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.EntityFramework;
using ScheduleOne.Management;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Management;
public class ObjectListFieldUI : MonoBehaviour
{
    [Header("References")]
    public string FieldText;
    public string InstructionText;
    public string ExtendedInstructionText;
    public TextMeshProUGUI FieldLabel;
    public GameObject NoneSelected;
    public GameObject MultipleSelected;
    public RectTransform[] Entries;
    public Button Button;
    public GameObject EditIcon;
    public GameObject NoMultiEdit;
    public List<ObjectListField> Fields { get; protected set; } = new List<ObjectListField>();

    public void Bind(List<ObjectListField> field);
    private void Refresh(List<BuildableItem> newVal);
    private void RemoveEntryClicked(int index);
    private bool AreFieldsUniform();
    public void Clicked();
    private bool ObjectValid(BuildableItem obj, out string reason);
    public void ObjectsSelected(List<BuildableItem> objs);
    public void Clear();
}