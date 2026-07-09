using UnityEngine;

namespace ScheduleOne.UI.Input;
[CreateAssetMenu(fileName = "InputPromptsSpriteData", menuName = "ScheduleOne/Input/Input Sprite Data", order = 1)]
public class InputPromptsSpriteData : ScriptableObject
{
    [Header("Properties")]
    public Sprite sprite;
    public Vector2 Size;
}