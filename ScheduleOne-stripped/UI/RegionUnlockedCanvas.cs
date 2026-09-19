using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.GameTime;
using ScheduleOne.Map;
using ScheduleOne.NPCs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class RegionUnlockedCanvas : Singleton<RegionUnlockedCanvas>, ISleepEvent
{
    public Animation OpenCloseAnim;
    public TextMeshProUGUI RegionLabel;
    public TextMeshProUGUI RegionDescription;
    public Image RegionImage;
    public UIScreen UIScreen;
    private EMapRegion region;
    public bool IsInProgress { get; private set; }
    public int EventOrder { get; private set; } = 5;

    public void QueueUnlocked(EMapRegion _region);
    public void StartEvent();
    public void EndEvent();
}