using System;
using System.Collections.Generic;
using ScheduleOne.Core.Avatar;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.CharacterCreator;
public class CharacterCreatorAvatarObjectSelector : MonoBehaviour
{
    [Header("References")]
    public RectTransform OptionContainer;
    [SerializeField]
    private GameObject OptionPrefab;
    [Header("Settings")]
    [SerializeField]
    private bool CanSelectNone;
    [SerializeField]
    private List<AvatarObject> Options;
    private List<Button> optionButtons;
    private Dictionary<Button, AvatarObject> buttonOptionMap;
    private AvatarObject _selection;
    public event Action<AvatarObject> OnSelectionChanged;
    protected void Awake();
    private void CreateButton(AvatarObject avatarObject);
    private void Select(AvatarObject selection);
    public void SetSelection(AvatarObject selection, bool notify);
    public void SetSelectionWithoutNotify(AvatarObject selection);
}