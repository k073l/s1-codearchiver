using System;
using System.Collections;
using ScheduleOne.Cartel;
using ScheduleOne.DevUtilities;
using ScheduleOne.Map;
using ScheduleOne.Persistence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class CartelInfluenceChangePopup : MonoBehaviour
{
    public const float SLIDER_ANIMATION_DURATION;
    public Animation Anim;
    public Slider Slider;
    public TextMeshProUGUI TitleLabel;
    public TextMeshProUGUI InfluenceCountLabel;
    private void Start();
    public void Show(EMapRegion region, float oldInfluence, float newInfluence);
    private void SetDisplayedInfluence(float influence);
}