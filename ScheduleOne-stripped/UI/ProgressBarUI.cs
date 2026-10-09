using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class ProgressBarUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private TextMeshProUGUI _progressLabel;
    [SerializeField]
    private Image _frontBarImage;
    [SerializeField]
    private Image _backBarImage;
    public void Set(float frontBarProgress, float backBarProgress = -1f, string label = "");
}