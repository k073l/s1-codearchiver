using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.UI.Handover;
using UnityEngine;

namespace ScheduleOne.UI;
public class HandoverStackSplitTutorialOpener : MonoBehaviour
{
    private bool _tutorialOpened;
    private void Awake();
    private void ScreenOpened(HandoverScreen.EMode mode);
    private void ScreenClose();
}