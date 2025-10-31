using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using TMPro;
using UnityEngine;

namespace ScheduleOne.UI.Compass;
public class CompassManager : Singleton<CompassManager>
{
    public class Notch
    {
        public RectTransform Rect;
        public CanvasGroup Group;
    }

    public class Element
    {
        public bool LastState;
        public bool Visible;
        public RectTransform Rect;
        public CanvasGroup Group;
        public TextMeshProUGUI DistanceLabel;
        public Transform Transform;
    }

    public const int NOTCH_COUNT;
    public const float DISTANCE_LABEL_THRESHOLD;
    [Header("References")]
    public RectTransform Container;
    public RectTransform NotchUIContainer;
    public RectTransform ElementUIContainer;
    public Canvas Canvas;
    [Header("Prefabs")]
    public GameObject DirectionIndicatorPrefab;
    public GameObject NotchPrefab;
    public GameObject ElementPrefab;
    [Header("Settings")]
    public bool CompassEnabled;
    public Vector2 ElementContentSize;
    public float CompassUIRange;
    public float FullAlphaRange;
    public float AngleDivisor;
    public float ClosedYPos;
    public float OpenYPos;
    private List<Vector3> notchPositions;
    private List<Notch> notches;
    private List<Element> elements;
    private Coroutine lerpContainerPositionCoroutine;
    private Transform cam => ((Component)PlayerSingleton<PlayerCamera>.Instance).transform;

    protected override void Awake();
    private void LateUpdate();
    private void Update();
    public void SetCompassEnabled(bool enabled);
    public void SetVisible(bool visible);
    private void UpdateNotches();
    private void UpdateElements();
    private void UpdateElement(Element element);
    public void GetCompassData(Vector3 worldPosition, out float xPos, out float alpha);
    public Element AddElement(Transform transform, RectTransform contentPrefab, bool visible = true);
    public void RemoveElement(Transform transform, bool alsoDestroyRect = true);
    public void RemoveElement(Element el, bool alsoDestroyRect = true);
}