using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class CrosshairText : MonoBehaviour
{
    public TextMeshProUGUI Label;
    private bool setThisFrame;
    private void Awake();
    private void LateUpdate();
    public void Show(string text, Color col = default(Color));
    public void Hide();
}