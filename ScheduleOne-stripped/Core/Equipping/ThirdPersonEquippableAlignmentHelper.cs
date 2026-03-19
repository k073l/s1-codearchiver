using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Core.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.Core.Equipping;
public class ThirdPersonEquippableAlignmentHelper : MonoBehaviour
{
    private const string HelperAvatarPrefabPath;
    private TPEquippedItem _equippedItem;
    private GameObject _helperAvatarInstance;
    [Button("Show Helper", "!_helperAvatarInstance")]
    public void ShowHelper();
    private void OnValidate();
    [Button("Hide Helper", "_helperAvatarInstance")]
    public void HideHelper();
    private void RefreshHelperAlignment();
}