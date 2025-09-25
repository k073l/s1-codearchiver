using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.MainMenu;
public class ConfirmExitScreen : MainMenuScreen
{
    public TextMeshProUGUI TimeSinceSaveLabel;
    private void Update();
    public void ConfirmExit();
}