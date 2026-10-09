using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.Avatar.Creation;
public abstract class AvatarEditorInputLinkerBase : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private bool _linkedByDefault;
    [SerializeField]
    private GameObject _targetInputBlocker;
    [SerializeField]
    private Toggle _linkToggle;
    protected bool _isLinked;
    public bool IsLinked => _isLinked;

    protected virtual void Awake();
    public void RestoreDefaultLinkState();
    public virtual void SetLinkState(bool isLinked);
    public abstract void SetLinkStateIfValuesMatch();
    protected void NotifySourceValueChanged();
    protected abstract void SetTargetValueToSourceValue(bool notify);
    protected abstract bool HasSource();
}