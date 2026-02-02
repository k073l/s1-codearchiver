using System.IO;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Settings;
[RequireComponent(typeof(Button))]
public class PlayerLogExporterButton : MonoBehaviour
{
    [SerializeField]
    private bool _exportPreviousLog;
    [SerializeField]
    private UnityEvent OnSuccess;
    private Button _button;
    private void Awake();
    private void OnEnable();
    private void OnButtonClick();
    private void Success();
    private bool DoesLogExist();
}