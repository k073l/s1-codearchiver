using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.MainMenu;
public class Disclaimer : MonoBehaviour
{
    public static bool Shown;
    public CanvasGroup Group;
    public CanvasGroup TextGroup;
    public UnityEvent OnClose;
    public float Duration;
    private void Awake();
    private void Fade();
}