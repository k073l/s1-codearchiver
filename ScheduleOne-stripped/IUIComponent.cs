using UnityEngine;

namespace ScheduleOne;
public interface IUIComponent
{
    RectTransform RectTransform { get; }

    float GetDirectionMatch(Vector2 dir, Vector2 screenPos);
    float GetDistance(Vector2 screenPos, Vector2 direction);
    Vector3 GetOrigin();
}