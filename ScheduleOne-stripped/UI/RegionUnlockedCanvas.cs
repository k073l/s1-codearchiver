using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.Map;
using ScheduleOne.NPCs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class RegionUnlockedCanvas : Singleton<RegionUnlockedCanvas>, IPostSleepEvent
{
    public Animation OpenCloseAnim;
    public TextMeshProUGUI RegionLabel;
    public TextMeshProUGUI RegionDescription;
    public Image RegionImage;
    private EMapRegion region;
    public bool IsRunning { get; private set; }
    public int Order { get; private set; } = 5;

    public void QueueUnlocked(EMapRegion _region);
    public void StartEvent();
    public void EndEvent();
}