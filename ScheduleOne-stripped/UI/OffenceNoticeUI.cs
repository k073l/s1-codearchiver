using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Police;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class OffenceNoticeUI : Singleton<OffenceNoticeUI>
{
    [Header("References")]
    [SerializeField]
    protected GameObject container;
    [SerializeField]
    protected List<Text> charges;
    [SerializeField]
    protected List<Text> penalties;
    protected override void Start();
    public void ShowOffenceNotice(Offense offence);
    private void Close();
}