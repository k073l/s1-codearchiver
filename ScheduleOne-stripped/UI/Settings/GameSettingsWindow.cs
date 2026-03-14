using FishNet;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.Settings;
public class GameSettingsWindow : MonoBehaviour
{
    public UIToggle ConsoleToggle;
    public GameObject Blocker;
    public UIPanel uiPanel;
    private void Awake();
    public void Start();
    public void ApplySettings(GameSettings settings);
    private void ConsoleToggled(bool value);
}