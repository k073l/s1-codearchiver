using System.Collections.Generic;
using EasyButtons;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.TV;
public class Snake : TVApp
{
    public enum EGameState
    {
        Ready,
        Playing
    }

    public const int SIZE_X;
    public const int SIZE_Y;
    [Header("Settings")]
    public SnakeTile TilePrefab;
    public float TimePerTile;
    [Header("References")]
    public RectTransform PlaySpace;
    public SnakeTile[] Tiles;
    public TextMeshProUGUI ScoreText;
    private Vector2 lastFoodPosition;
    private float _timeSinceLastMove;
    private float _timeOnGameOver;
    public UnityEvent onStart;
    public UnityEvent onEat;
    public UnityEvent onGameOver;
    public UnityEvent onWin;
    public Vector2 HeadPosition { get; private set; } = new Vector2(10f, 6f);
    public List<Vector2> Tail { get; private set; } = new List<Vector2>();
    public Vector2 LastTailPosition { get; private set; } = Vector2.zero;
    public Vector2 Direction { get; private set; } = Vector2.right;
    public Vector2 QueuedDirection { get; private set; } = Vector2.right;
    public Vector2 NextDirection { get; private set; } = Vector2.zero;
    public EGameState GameState { get; private set; }

    protected override void Awake();
    private void Update();
    private void UpdateInput();
    private void UpdateMovement();
    private void MoveSnake();
    private SnakeTile GetTile(Vector2 position);
    private void StartGame(Vector2 initialDir);
    private void Eat();
    private void SpawnFood();
    private void GameOver();
    private void Win();
    protected override void TryPause();
    [Button]
    public void CreateTiles();
}