using System;
using ScheduleOne.Core.Avatar;
using ScheduleOne.Core.Avatar.Properties;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.Avatar.Creation;
public class AvatarObjectEntry : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nameLabel;
    [SerializeField]
    private Button _expandButton;
    [SerializeField]
    private Button _removeButton;
    [SerializeField]
    private RectTransform _propertiesContainer;
    [Header("Properties Prefab")]
    [SerializeField]
    private AvatarObjectColorEntry _colorEntryPrefab;
    private AvatarObject _avatarObject;
    public AvatarObject AvatarObject => _avatarObject;

    public event Action OnRemovePressed;
    public void Initialize(AvatarObject avatarObject);
    public void Destroy();
    private void CreatePropertyEntry(AvatarPropertyBase property);
}