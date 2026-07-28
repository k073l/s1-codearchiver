using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.CharacterCreator;
public class CharacterCreatorMenu : MonoBehaviour
{
    [Serializable]
    public class Window
    {
        public string Name;
        public RectTransform Container;
        public UIPanel Panel;
        public void Open();
        public void Close();
    }

    public Window[] Windows;
    [Header("References")]
    public TextMeshProUGUI CategoryLabel;
    public Button BackButton;
    public Button NextButton;
    [Header("UI")]
    [SerializeField]
    private CyclerController _cyclerController;
    [SerializeField]
    private UIScreen _screen;
    private int openWindowIndex;
    private Window openWindow;
    public void Start();
    public void OpenWindow(int index);
    private void HandleCycleEvent(int dir);
    private void Back();
    private void Next();
}