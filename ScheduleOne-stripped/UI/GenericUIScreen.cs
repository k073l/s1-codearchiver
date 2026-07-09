using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI;
public class GenericUIScreen : MonoBehaviour
{
    [Header("Settings")]
    public string Name;
    [Header("References")]
    public MonoState State;
    public UnityEvent onOpen;
    public UnityEvent onClose;
    public bool IsOpen { get; private set; }

    private void Awake();
    public void Open();
    private void OnOpen();
    public void Close();
    private void OnClose();
}