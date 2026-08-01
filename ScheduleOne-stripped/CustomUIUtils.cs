using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace ScheduleOne;
public static class CustomUIUtils
{
    public class CandidateInfo<T>
    {
        public T Candidate;
        public float DirectionMatch;
        public float Distance;
        public float Score;
        public CandidateInfo(T candidate, float directionMatch, float distance, float score);
    }

    public static Mouse GetSystemMouse();
    public static Mouse GetVirtualMouse();
    public static Vector2 GetScreenPosition(Canvas canvas, RectTransform selectable);
    public static Vector2 GetScreenPosition(Canvas canvas, Vector3 worldPosition);
    public static List<UISelectable> GetSelectables(UIScreen screen, UIPanel current = null, bool includeCurrentPanel = true);
    public static T FindBestElementWeighted<T>(Vector2 dir, Canvas canvas, T current, List<T> candidates, UIContentPanel.NavigationSettings settings, out List<CandidateInfo<T>> validCandidates)
        where T : IUIComponent;
    public static bool RaycastRectTransform(RectTransform rect, Canvas canvas, Vector2 p, Vector2 d, out Vector2 hitPoint);
    private static float GetWeightedScore(float directionMatch, float distance, float directionWeight, float distanceWeight);
    public static float GetDirectionMatch(Vector2 dir, Vector2 fromScreenPos, Vector2 toScreenPos);
    public static float GetDirectionMatchForCorners(Vector2 dir, Vector2 screenPos, RectTransform rectTransform, Canvas canvas, float intersectionOffset = 50f);
    public static float GetDistanceOfClosestPoint(Vector2 screenPos, RectTransform rectTransform, Canvas canvas);
    public static Vector2 SnapDirection(Vector2 dir, float threshold = 0.1f);
    public static bool IsHorizontal(Vector2 val, float threshold = 0.2f);
    public static bool IsVertical(Vector2 val, float threshold = 0.2f);
    public static ScreenDirection ToScreenDirection(Vector2 val);
    public static Vector2 ClampToDirection(Vector2 val, Vector2 dir);
}