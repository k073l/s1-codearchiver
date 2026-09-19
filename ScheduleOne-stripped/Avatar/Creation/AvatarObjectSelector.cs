using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Core.Avatar;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne.Avatar.Creation;
public class AvatarObjectSelector : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private TMP_InputField _searchInputField;
    [SerializeField]
    private Button _closeButton;
    [SerializeField]
    private RectTransform _entryContainer;
    [Header("Prefabs")]
    [SerializeField]
    private GameObject _entryPrefab;
    private Action<AvatarObject> _onObjectSelectedCallback;
    private Dictionary<AvatarObject, GameObject> _entryMap;
    private Type _typeFilter;
    private void Awake();
    private void Update();
    private void OnSearchValueChanged(string searchText);
    private void FilterEntries(string searchText);
    private bool MatchesTypeFilter(AvatarObject avatarObject);
    private void Select(AvatarObject avatarObject);
    public void Open(Action<AvatarObject> onObjectSelectedCallback, Type typeFilter = null);
    public void Close();
}