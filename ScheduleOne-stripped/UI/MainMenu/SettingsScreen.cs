using System;
using System.Collections;
using FishNet;
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
    public GameObject[] HostOnlyGameObjects;
    public UITab Tab;
    private bool _initialized;
    private void OnEnable();
    protected override void Awake();
    protected override void OnOpen();
    public void ShowCategory(int index);
    public void ApplyDisplaySettings(bool showRevertMenu);
}