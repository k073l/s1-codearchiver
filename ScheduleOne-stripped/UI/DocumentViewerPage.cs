using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI;
public class DocumentViewerPage : MonoBehaviour
{
    public string Name;
    public UnityEvent OnPageViewed;
    public void Open();
    public void Close();
}