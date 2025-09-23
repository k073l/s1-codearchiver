using System;
using System.Collections;
using ScheduleOne.Cartel;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class CartelStatusChangePopup : MonoBehaviour
{
    public Animation Anim;
    public TextMeshProUGUI OldStatusLabel;
    public TextMeshProUGUI NewStatusLabel;
    public Color UnknownColor;
    public Color TrucedColor;
    public Color HostileColor;
    public Color DefeatedColor;
    private void Start();
    public void Show(ECartelStatus oldStatus, ECartelStatus newStatus);
    private Color GetColor(ECartelStatus status);
}