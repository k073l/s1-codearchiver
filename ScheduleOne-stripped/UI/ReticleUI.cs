using System;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.UI;
public class ReticleUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private ReticleLineUI[] _lineUI;
    [SerializeField]
    private CanvasGroup _canvas;
    [Header("Settings")]
    [SerializeField]
    private float _lineLength;
    [SerializeField]
    private float _lineThickness;
    [SerializeField]
    private float _borderThickness;
    [SerializeField]
    private Color _lineColor;
    [SerializeField]
    private Color _borderColor;
    [SerializeField]
    private float _minGap;
    [SerializeField]
    private float _lerpSpeed;
    private float _radius;
    private float _currentRadius;
    private float _lastSpreadAngle;
    public float Alpha { get; set; }

    private void Awake();
    private void OnValidate();
    public void Set(float spreadAngle);
    private void Update();
    private void ApplyLineSizes();
    private void ApplyColors();
}