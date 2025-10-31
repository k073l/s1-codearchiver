using System.Linq;
using ScheduleOne.UI.WorldspacePopup;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public class CopyPosition : MonoBehaviour
{
    public Transform ToCopy;
    private void Start();
    private void LateUpdate();
    public void UpdateEnabledState();
}