using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.TV;
public class Pong : TVApp
{
    public enum EGameMode
    {
        SinglePlayer,
        MultiPlayer
    }

    public enum ESide
    {
        Left,
        Right
    }

    public enum EState
    {
        Ready,
        Playing,
        GameOver
    }

    public RectTransform Rect;
    public PongPaddle LeftPaddle;
    public PongPaddle RightPaddle;
    public PongBall Ball;
    public TextMeshProUGUI LeftScoreLabel;
    public TextMeshProUGUI RightScoreLabel;
    public TextMeshProUGUI WinnerLabel;
    [Header("Settings")]
    public float InitialVelocity;
    public float VelocityGainPerSecond;
    public float MaxVelocity;
    public int GoalsToWin;
    [Header("AI")]
    public float ReactionTime;
    public float TargetRandomization;
    public float SpeedMultiplier;
    public UnityEvent onServe;
    public UnityEvent onLeftScore;
    public UnityEvent onRightScore;
    public UnityEvent onGameOver;
    public UnityEvent onLocalPlayerWin;
    public UnityEvent onReset;
    private ESide nextBallSide;
    private Vector3 ballVelocity;
    private float reactionTimer;
    public EGameMode GameMode { get; set; }
    public EState State { get; set; }
    public int LeftScore { get; set; }
    public int RightScore { get; set; }

    private void Update();
    private void FixedUpdate();
    protected override void TryPause();
    public void UpdateInputs();
    private void UpdateAI();
    public void GoalHit(ESide side);
    private void Win(ESide winner);
    private void ResetBall();
    private void ServeBall();
    private void ResetGame();
    public void SetPaddleTargetY(ESide player, float y);
    public override void Resume();
}