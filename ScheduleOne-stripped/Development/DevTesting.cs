using ScheduleOne.Core;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScheduleOne.Development;
public class DevTesting : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private string _example;
    [SerializeField]
    private TextMeshProUGUI _temp;
    [Button]
    private void GetRequiredSize();
    private void Update();
}