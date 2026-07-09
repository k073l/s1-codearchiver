using System;
using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.Casino.UI;
public class RTBInterface : Singleton<RTBInterface>
{
    [Header("References")]
    public Canvas Canvas;
    public GameObject Container;
    public CasinoGamePlayerDisplay PlayerDisplay;
    public CasinoGameBetPanel BetPanel;
    public TextMeshProUGUI StatusLabel;
    public TextMeshProUGUI WinningsMultiplierLabel;
    public UIScreen UIScreen;
    public UIPanel AnswerPanel;
    [Header("Question and answers")]
    public TextMeshProUGUI QuestionLabel;
    public Slider TimerSlider;
    public Button[] AnswerButtons;
    public TextMeshProUGUI[] AnswerLabels;
    public Button ForfeitButton;
    public TextMeshProUGUI ForfeitLabel;
    public Animation QuestionContainerAnimation;
    public AnimationClip QuestionContainerFadeIn;
    public AnimationClip QuestionContainerFadeOut;
    public CanvasGroup QuestionCanvasGroup;
    public RectTransform SelectionIndicator;
    public UnityEvent onCorrect;
    public UnityEvent onFinalCorrect;
    public UnityEvent onIncorrect;
    public RTBGameController CurrentGame { get; private set; }

    protected override void Awake();
    private void Update();
    private string GetStatusText();
    public void Open(RTBGameController game);
    public void Close();
    private void QuestionReady(string question, string[] answers);
    private void AnswerButtonClicked(int index);
    private void ForfeitClicked();
    private void QuestionDone();
    private void LocalPlayerExitRound();
    private void Correct();
    private void Incorrect();
    private void ReadyButtonClicked();
}