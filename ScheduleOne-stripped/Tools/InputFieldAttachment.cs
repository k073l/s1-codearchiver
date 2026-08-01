using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.Tools;
public class InputFieldAttachment : MonoBehaviour
{
    private bool _isTyping;
    private void Awake();
    private void EditStart(string newVal);
    private void EndEdit(string newVal);
    private void OnDisable();
    private void OnDestroy();
}