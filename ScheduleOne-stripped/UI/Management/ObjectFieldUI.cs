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
public class ObjectFieldUI : MonoBehaviour
{
    [Header("References")]
    public string InstructionText;
    public string ExtendedInstructionText;
    public TextMeshProUGUI FieldLabel;
    public Image IconImg;
    public TextMeshProUGUI SelectionLabel;
    public GameObject NoneSelected;
    public GameObject MultipleSelected;
    public RectTransform ClearButton;
    public List<ObjectField> Fields { get; protected set; } = new List<ObjectField>();

    public void Bind(List<ObjectField> field);
    private void Refresh(BuildableItem newVal);
    private bool AreFieldsUniform();
    public void Clicked();
    private bool ObjectValid(BuildableItem obj, out string reason);
    public void ObjectsSelected(List<BuildableItem> objs);
    private void ObjectSelected(BuildableItem obj);
    public void ClearClicked();
}