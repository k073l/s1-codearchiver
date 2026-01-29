using System;
using EasyButtons;
using ScheduleOne.Audio;
using UnityEngine;

namespace ScheduleOne.Storage;
public class StorageDoorAnimation : MonoBehaviour
{
    [SerializeField]
    private bool _loggingEnabled;
    private bool overriddeIsOpen;
    private bool overrideState;
    [SerializeField]
    private bool _disableItemContainerWhenClosed;
    [Header("Animations")]
    public Animation[] Anims;
    public AnimationClip OpenAnim;
    public AnimationClip CloseAnim;
    public AudioSourceController OpenSound;
    public AudioSourceController CloseSound;
    private StorageEntity storageEntity;
    private Transform itemContainer;
    public bool IsOpen { get; protected set; }

    private void Start();
    [Button]
    public void Open();
    [Button]
    public void Close();
    public void SetIsOpen(bool open);
    protected virtual void RefreshItemsVisible();
    public void OverrideState(bool open);
    public void ResetOverride();
}