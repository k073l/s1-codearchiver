using System;
using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class StaminaBar : MonoBehaviour
{
    public const float StaminaShowTime;
    public const float StaminaFadeTime;
    [Header("References")]
    public Slider[] Sliders;
    public CanvasGroup Group;
    private Coroutine routine;
    private void Awake();
    private void PlayerSpawned();
    private void UpdateStaminaBar(float change);
}