using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.Avatar.Creation;
public class AvatarEditorCollapsibleSection : MonoBehaviour
{
    [SerializeField]
    private bool _startExpanded;
    [Tooltip("Optionally enable the container in awake to ensure scripts underneath it receive Awake calls. The container will then be immediately returned to its original state.")]
    [SerializeField]
    private bool _brieflyExpandOnAwake;
    [SerializeField]
    private Toggle _toggle;
    [SerializeField]
    private GameObject _container;
    private void Awake();
    private void OnToggleValueChanged(bool isOn);
}