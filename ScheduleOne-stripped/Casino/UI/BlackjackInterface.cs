using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.Casino.UI;
public class BlackjackInterface : Singleton<BlackjackInterface>
{
    [Header("References")]
    public Canvas Canvas;
    public GameObject Container;
    public CasinoGamePlayerDisplay PlayerDisplay;
    public RectTransform WaitingContainer;
    public TextMeshProUGUI WaitingLabel;
    public TextMeshProUGUI DealerScoreLabel;
    public TextMeshProUGUI PlayerScoreLabel;
    public UIPanel InputPanel;
    public Button HitButton;
    public Button StandButton;
    public Animation InputContainerAnimation;
    public CanvasGroup InputContainerCanvasGroup;
    public AnimationClip InputContainerFadeIn;
    public AnimationClip InputContainerFadeOut;
    public RectTransform SelectionIndicator;
    public Animation ScoresContainerAnimation;
    public CanvasGroup ScoresContainerCanvasGroup;
    public TextMeshProUGUI PositiveOutcomeLabel;
    public TextMeshProUGUI PayoutLabel;
    public CasinoGameBetPanel BetPanel;
    public UIScreen UIScreen;
    public UnityEvent onBust;
    public UnityEvent onBlackjack;
    public UnityEvent onWin;
    public UnityEvent onLose;
    public UnityEvent onPush;
    public BlackjackGameController CurrentGame { get; private set; }

    protected override void Awake();
    private void Update();
    public void Open(BlackjackGameController game);
    public void Close();
    private void LocalPlayerReadyForInput();
    private void ShowScores();
    private void HideScores();
    private void HitClicked();
    private void StandClicked();
    private void LocalPlayerExitRound();
    private void ReadyButtonClicked();
    private void OnLocalPlayerBust();
    private void OnLocalPlayerRoundCompleted(BlackjackGameController.EPayoutType payout);
}