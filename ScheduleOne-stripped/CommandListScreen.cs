using System.Collections.Generic;
using ScheduleOne.UI.MainMenu;
using TMPro;
using UnityEngine;

namespace ScheduleOne;
public class CommandListScreen : MenuScreen
{
    public RectTransform CommandEntryContainer;
    public RectTransform CommandEntryPrefab;
    private List<RectTransform> commandEntries;
    private void Start();
}