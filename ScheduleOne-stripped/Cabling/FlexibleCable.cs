using System;
using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.Cabling;
[RequireComponent(typeof(LineRenderer))]
public class FlexibleCable : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private LineRenderer _line;
    [Header("Connection Points")]
    public Transform startPoint;
    public Transform endPoint;
    [Header("Visual Settings")]
    [Range(2f, 50f)]
    public int segments;
    public float startWidth;
    public float endWidth;
    [Tooltip("Leave blank to use default URP Unlit material")]
    public Material cableMaterial;
    [Header("Color Gradient Settings")]
    [Tooltip("Defines the red channel intensity from the edge (0) to the center (1).")]
    public AnimationCurve colorCurve;
    [Header("Physics & Gravity")]
    public float sagAmount;
    [Range(0f, 1f)]
    public float tension;
    public Vector3 sagDirection;
    [Header("Catenary Settings")]
    [Range(0.1f, 5f)]
    [Tooltip("Controls the curve shape. Lower = V-shape, Higher = U-shape (Heavy cable)")]
    public float catenaryShape;
    [Header("Dynamic Limits")]
    [SerializeField]
    private Vector2 _minMaxTension;
    [SerializeField]
    private Vector2 _minMaxSag;
    [Header("Debugging")]
    [SerializeField]
    private bool _showInEditor;
    [HideInInspector]
    [SerializeField]
    private Vector3[] _serialisedPosition;
    public Vector3[] SerialisedPosition => _serialisedPosition;

    private void Awake();
    public void Start();
    private void LateUpdate();
    private void DrawCable();
    [Button("Bake Cable")]
    public void BakeCablePositions();
    [Button("Clear Bake")]
    public void ClearBakedPositions();
    public void SetTension(float newTension);
    public void SetTensionByMinMax(float percentage);
    public void SetSagByMinMax(float percentage);
    private void OnDrawGizmos();
}