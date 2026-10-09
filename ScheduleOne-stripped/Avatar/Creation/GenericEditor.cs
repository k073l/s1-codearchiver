using System;
using System.Collections.Generic;
using ScheduleOne.Core.Avatar;
using UnityEngine;

namespace ScheduleOne.Avatar.Creation;
public abstract class GenericEditor : MonoBehaviour
{
    [SerializeField]
    protected AvatarAppearance _previewAvatar;
    protected List<AvatarObject> _appliedObjects;
    public event Action<AvatarObject> OnAppliedObjectAdded;
    public event Action<AvatarObject> OnAppliedObjectRemoved;
    public void AddAvatarObject(AvatarObject objPrefab);
    public void AddAvatarObject(SerializedAvatarObject obj);
    public void RemoveAvatarObject(AvatarObject objectReference);
    protected abstract Func<SerializedAvatarObject, AvatarObject> GetAddAvatarObjectMethod();
    protected abstract Action<AvatarObject> GetRemoveAvatarObjectMethod();
    protected List<SerializedAvatarObject> SerializeAppliedObjects();
    protected virtual void ResetPreviewAvatar();
}