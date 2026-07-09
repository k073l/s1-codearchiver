using System;
using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI.Settings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.MainMenu;
public class SettingsScreen : MenuScreen
{
    [Serializable]
    public class SettingsCategory
    {
        public Toggle Toggle;
        public GameObject Panel;
    }

    public SettingsCategory[] Categories;
    public Button ApplyDisplayButton;
    public ConfirmDisplaySettings ConfirmDisplaySettings;
    public GameObject ActiveDisplaySelection;
    protected override void Awake();
    protected void Start();
    public void ShowCategory(int index);
    public void ApplyDisplaySettings(bool showRevertMenu);
}