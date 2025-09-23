using System;
using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class CrimeStatusUI : MonoBehaviour
{
    public const float SmallTextSize;
    public const float LargeTextSize;
    [Header("References")]
    public RectTransform CrimeStatusContainer;
    public CanvasGroup CrimeStatusGroup;
    public GameObject BodysearchLabel;
    public Image InvestigatingMask;
    public Image UnderArrestMask;
    public Image WantedMask;
    public Image WantedDeadMask;
    public GameObject ArrestProgressContainer;
    private bool animateText;
    private Coroutine routine;
    public void UpdateStatus();
    private void OnDestroy();
    private IEnumerator Routine();
}