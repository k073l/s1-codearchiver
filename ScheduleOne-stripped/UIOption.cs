using TMPro;
using UnityEngine;

namespace ScheduleOne;
public abstract class UIOption : MonoBehaviour
{
    public struct OptionInfo
    {
        public string OptionName;
        public int OptionIndex;
    }

    [SerializeField]
    protected UISelectable selectable;
    [SerializeField]
    protected TextMeshProUGUI nameText;
    [SerializeField]
    protected string optionName;
    private const float MoveThreshold;
    private bool wasNavPressedLastFrame;
    private float navTimer;
    protected virtual float NavigationRepeatRateMult => 1f;

    protected virtual void Awake();
    private void OnValidate();
    private void Update();
    protected virtual void OnUpdate();
    protected virtual void MoveLeft();
    protected virtual void MoveRight();
    protected virtual void DetectInput();
    protected virtual bool Navigate(Vector2 navDir);
}