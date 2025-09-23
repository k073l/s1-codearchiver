using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.Storage;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Employees;
public class EmployeeHome : MonoBehaviour
{
    public string HomeType;
    [Header("References")]
    public GameObject Clipboard;
    public SpriteRenderer MugshotSprite;
    public TextMeshPro NameLabel;
    public StorageEntity Storage;
    public MeshRenderer[] EmployeeSpecificMeshes;
    public Material SpecificMat_Default;
    public Material SpecificMat_Botanist;
    public Material SpecificMat_Chemist;
    public Material SpecificMat_Packager;
    public Material SpecificMat_Cleaner;
    public UnityEvent onAssignedEmployeeChanged;
    public Employee AssignedEmployee { get; protected set; }

    private void Awake();
    private void Start();
    public void SetAssignedEmployee(Employee employee);
    private void UpdateStorageText();
    private void UpdateMaterial();
    public float GetCashSum();
    public void RemoveCash(float amount);
    public static bool IsBuildableEntityAValidEmployeeHome(BuildableItem obj, out string reason);
}