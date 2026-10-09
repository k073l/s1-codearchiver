using System.Collections.Generic;
using ScheduleOne.Core.Avatar;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.Avatar.Creation;
public abstract class GenericEditorInterface<T> : MonoBehaviour where T : GenericEditor
{
    [SerializeField]
    protected T _editor;
    [Header("UI References")]
    [SerializeField]
    protected TMP_InputField _assetNameInputField;
    [SerializeField]
    private Button _saveButton;
    [SerializeField]
    private Button _loadButton;
    [SerializeField]
    private Button _addAvatarObjectButton;
    [SerializeField]
    private RectTransform _avatarObjectEntriesContainer;
    [SerializeField]
    private AvatarObjectSelector _objectSelector;
    [Header("Prefabs")]
    [SerializeField]
    private AvatarObjectEntry _avatarObjectEntryPrefab;
    protected List<AvatarObjectEntry> _avatarObjectEntries;
    public AvatarObjectSelector ObjectSelector => _objectSelector;

    protected virtual void Awake();
    protected abstract void SaveButtonClicked();
    protected abstract void LoadButtonClicked();
    private void OpenAvatarObjectSelector();
    protected virtual void AppliedAvatarObjectAdded(AvatarObject obj);
    protected virtual void AppliedAvatarObjectRemoved(AvatarObject obj);
    protected void SetAllLinkerStatesIfValuesMatch();
    protected void SetAllLinkerStates(bool state);
    private void CreateEntry(AvatarObject obj);
    private void RemoveEntry(AvatarObject obj);
    private bool TryGetEntry(AvatarObject obj, out AvatarObjectEntry entry);
}