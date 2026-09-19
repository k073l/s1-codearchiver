using System.IO;
using UnityEngine;

namespace ScheduleOne.Property;
[RequireComponent(typeof(Property))]
public class ApplyPropertyDefaultSave : MonoBehaviour
{
    [Header("Do not include the .json extension in the path!")]
    [SerializeField]
    private string _defaultSaveFilePath;
    private void Awake();
    private void OnValidate();
    public string GetDefaultSaveContents();
    public string GetDefaultSaveFileFullPath();
}