using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class ReticleLineUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Image _line;
    [SerializeField]
    private Image _border;
    public void SetPosition(Vector2 position);
    public void SetSize(float sizeX, float sizeY, float thickness);
    public void SetColor(Color lineColor, Color borderColor);
}